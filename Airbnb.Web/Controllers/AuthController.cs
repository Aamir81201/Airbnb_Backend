using Airbnb.Model.Common.Enum;
using Airbnb.Model.CustomModels;
using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Model.Models;
using Airbnb.Web.Auth;
using Airbnb.Web.Services;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly AuthService authService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly IWebHostEnvironment environment;

        public AuthController(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, RoleManager<IdentityRole<Guid>> roleManager, IWebHostEnvironment environment)
        {
            this.authService = new AuthService(configuration, userManager);
            this.configuration = configuration;
            this.userManager = userManager;
            this.signManager = signManager;
            this.roleManager = roleManager;
            this.environment = environment;
        }

        [HttpGet("IsUserExists")]
        public async Task<IActionResult> IsUserExists(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Ok(new UserStateResponseDTO() { State = PreSignupEnum.signup.ToString() });
                }
                else
                {
                    return Ok(new UserStateResponseDTO()
                    {
                        State = PreSignupEnum.password.ToString(),
                        UserProfile = new UserProfileResponseDTO()
                        {
                            UserId = user.Id,
                            Email = user.Email,
                            Name = user.FirstName,
                            Provider = userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider,
                            Avatar = user.Avatar
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("GetSavedUsers")]
        public async Task<IActionResult> GetSavedUsers(IEnumerable<Guid> userIds)
        {
            try
            {
                IEnumerable<ApplicationUser> users = await userManager.Users.Where(user => userIds.Contains(user.Id)).ToListAsync();
                IEnumerable<UserProfileResponseDTO> userProfile = users.Select(user => new UserProfileResponseDTO()
                {
                    UserId = user.Id,
                    Name = user.FirstName,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    Provider = userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider,
                }).ToList();
                return Ok(userProfile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            try
            {
                ApplicationUser user = await userManager.FindByEmailAsync(userLoginRequestDTO.Email);
                if (user != null)
                {
                    var signIn = await signManager.PasswordSignInAsync(user, userLoginRequestDTO.Password, false, false);

                    if (signIn.Succeeded)
                    {
                        string jwtToken = await authService.GenerateToken(user);
                        return Ok(jwtToken);
                    }
                }
                return BadRequest(new { title = "Invalid", message = "Invalid login details. Please try again." });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("PreUserSignUp")]
        public async Task<IActionResult> PreUserSignUp(UserSignUpRequestDTO userSignUpRequestDTO)
        {
            try
            {
                ApplicationUser? user = await userManager.FindByEmailAsync(userSignUpRequestDTO.Email);
                var userStateResponseDTO = new UserStateResponseDTO();
                if (user != null)
                {
                    var signIn = await signManager.PasswordSignInAsync(user, userSignUpRequestDTO.Password, false, false);
                    if (signIn != null && signIn.Succeeded)
                    {
                        string jwtToken = await authService.GenerateToken(user);

                        userStateResponseDTO.State = PreSignupEnum.login.ToString();
                        userStateResponseDTO.Token = jwtToken;
                    }
                    else
                    {
                        userStateResponseDTO.State = PreSignupEnum.password.ToString();
                        userStateResponseDTO.UserProfile = new UserProfileResponseDTO()
                        {
                            UserId = user.Id,
                            Email = user.Email,
                            Name = user.FirstName,
                            Provider = userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider,
                            Avatar = user.Avatar
                        };
                    }
                }
                else
                {
                    userStateResponseDTO.State = PreSignupEnum.signup.ToString();
                }
                return Ok(userStateResponseDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("UserSignUp")]
        public async Task<IActionResult> UserSignUp(UserSignUpRequestDTO userSignUpRequestDTO)
        {
            try
            {
                var user = new ApplicationUser()
                {
                    UserName = userSignUpRequestDTO.Email,
                    FirstName = userSignUpRequestDTO.FirstName,
                    LastName = userSignUpRequestDTO.LastName,
                    DateOfBirth = userSignUpRequestDTO.DateOfBirth,
                    RecieveMarketingMessages = userSignUpRequestDTO.RecieveMarketingMessages,
                    Email = userSignUpRequestDTO.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, userSignUpRequestDTO.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, RoleEmum.User.ToString());
                    await signManager.SignInAsync(user, false);

                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var emailConfiguration = configuration.GetSection(nameof(EmailConfiguration)).Get<EmailConfiguration>();
                    var emailSender = new EmailSender(emailConfiguration, environment);
                    var message = emailSender.GenerateEmailMessage(user.Email, user.FirstName, token, EmailTypeEnum.EmailVerification);
                    var ismailSent = await emailSender.SendEmailAsync(message);

                    string jwtToken = await authService.GenerateToken(user);

                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("PreExternalAuthentication")]
        public async Task<IActionResult> PreExternalAuthentication(UserExternalAuthRequestDTO userExternalAuthRequestDTO)
        {
            try
            {
                if (userExternalAuthRequestDTO.Provider == ProviderEnum.GOOGLE.ToString())
                {
                    GoogleJsonWebSignature.Payload? payload = await authService.VerifyGoogleToken(userExternalAuthRequestDTO);

                    if (payload != null)
                    {
                        var info = new UserLoginInfo(userExternalAuthRequestDTO.Provider, payload.Subject, userExternalAuthRequestDTO.Provider);
                        var user = await userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                        if (user == null)
                        {
                            user = await userManager.FindByEmailAsync(payload.Email);
                            if (user == null)
                            {
                                var userState = new UserStateResponseDTO()
                                {
                                    State = PreSignupEnum.signup.ToString()
                                };
                                return Ok(userState);
                            }
                            else
                            {
                                var userState = new UserStateResponseDTO()
                                {
                                    State = PreSignupEnum.password.ToString(),
                                    UserProfile = new UserProfileResponseDTO()
                                    {
                                        UserId = user.Id,
                                        Email = user.Email,
                                        Name = user.FirstName,
                                        Provider = userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider,
                                        Avatar = user.Avatar
                                    }
                                };
                                return Ok(userState);
                            }
                        }
                        else
                        {
                            string jwtToken = await authService.GenerateToken(user);

                            var userState = new UserStateResponseDTO()
                            {
                                State = PreSignupEnum.login.ToString(),
                                Token = jwtToken
                            };
                            return Ok(userState);
                        }
                    }
                }
                return BadRequest("I don't know");
            }
            catch
            {
                return BadRequest("Something terrible");
            }
        }

        [HttpPost("ExternalSignUp")]
        public async Task<IActionResult> ExternalSignUp(UserSignUpRequestDTO userSignUp)
        {
            try
            {
                if (userSignUp.ExternalUserAuth!.Provider == ProviderEnum.GOOGLE.ToString())
                {
                    GoogleJsonWebSignature.Payload? payload = await authService.VerifyGoogleToken(userSignUp.ExternalUserAuth);

                    if (payload != null)
                    {
                        var info = new UserLoginInfo(userSignUp.ExternalUserAuth.Provider, payload.Subject, userSignUp.ExternalUserAuth.Provider);
                        var user = await userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                        if (user == null)
                        {
                            user = await userManager.FindByEmailAsync(payload.Email);
                            if (user == null)
                            {
                                user = new ApplicationUser()
                                {
                                    Email = userSignUp.Email,
                                    UserName = userSignUp.Email,
                                    FirstName = userSignUp.FirstName,
                                    DateOfBirth = userSignUp.DateOfBirth,
                                    RecieveMarketingMessages = userSignUp.RecieveMarketingMessages,
                                    LastName = userSignUp.LastName,
                                    Avatar = payload.Picture
                                };

                                await userManager.CreateAsync(user);
                                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                                var emailConfiguration = configuration.GetSection(nameof(EmailConfiguration)).Get<EmailConfiguration>();
                                var emailSender = new EmailSender(emailConfiguration, environment);
                                var message = emailSender.GenerateEmailMessage(user.Email, user.FirstName, token, EmailTypeEnum.EmailVerification);
                                var ismailSent = await emailSender.SendEmailAsync(message);
                                await userManager.AddToRoleAsync(user, RoleEmum.User.ToString());
                                await userManager.AddLoginAsync(user, info);

                                var jwtToken = await authService.GenerateToken(user);

                                return Ok(jwtToken);
                            }
                        }
                    }
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("SendResetPasswordMail")]
        public async Task<IActionResult> SendResetPasswordMail(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Ok(false);
                }
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var emailConfiguration = configuration.GetSection(nameof(EmailConfiguration)).Get<EmailConfiguration>();
                var emailSender = new EmailSender(emailConfiguration, environment);
                var message = emailSender.GenerateEmailMessage(user.Email, user.FirstName, token, EmailTypeEnum.PasswordReset);
                var ismailSent = await emailSender.SendEmailAsync(message);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet("VerifyResetPassword")]
        public async Task<IActionResult> VerifyResetPassword(string email, string token)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var isTokenValid = await userManager.VerifyUserTokenAsync(user, userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
                if (isTokenValid)
                {
                    var userAuth = new UserAuthModel()
                    {
                        UserId = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                    return Ok(userAuth);
                }
                BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserResetPasswordModel resetPassword)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(resetPassword.Email);
                var PasswordResult = await signManager.CheckPasswordSignInAsync(user, resetPassword.NewPassword, true);
                if (PasswordResult.Succeeded)
                {
                    return BadRequest(new { title = "Invalid", message = "Your new password cannot be the same as the old password." });
                }
                var result = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

                if (result.Succeeded)
                {
                    string jwtToken = await authService.GenerateToken(user);
                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}