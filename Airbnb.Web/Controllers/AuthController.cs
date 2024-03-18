using Airbnb.Model.Common.Enum;
using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Model.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Airbnb.Model.Common.HelperMethods;
using Airbnb.Service.Interface;
using Airbnb.Model.CustomModels;
using AutoMapper;
using System.Data;

namespace Airbnb.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, RoleManager<IdentityRole<Guid>> roleManager, IEmailService emailService, IMapper mapper)
        {
            _configuration = configuration;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpGet("IsUserExists/{email}")]
        public async Task<IActionResult> IsUserExists(string email)
        {
            try
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(email);
                return Ok(user != null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("UserProfile/{email}")]
        public async Task<IActionResult> GetUserProfile(string email)
        {
            try
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    UserProfileResponseDTO userProfileResponseDTO = _mapper.Map<UserProfileResponseDTO>(user);
                    userProfileResponseDTO.Provider = _userManager.GetLoginsAsync(user).GetAwaiter().GetResult().FirstOrDefault()?.LoginProvider;
                    return Ok(userProfileResponseDTO);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet("UserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                string userId = _userManager.GetUserId(User);
                ApplicationUser? user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest();
                }
                else
                {
                    UserProfileResponseDTO userProfileResponseDTO = _mapper.Map<UserProfileResponseDTO>(user);
                    userProfileResponseDTO.Provider = _userManager.GetLoginsAsync(user).GetAwaiter().GetResult().FirstOrDefault()?.LoginProvider;
                    return Ok(userProfileResponseDTO);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("UserProfiles")]
        public async Task<IActionResult> GetUserProfiles([FromBody] IEnumerable<Guid> userIds)
        {
            try
            {
                IEnumerable<ApplicationUser> users = await _userManager.Users.Where(user => userIds.Contains(user.Id)).ToListAsync();
                IEnumerable<UserProfileResponseDTO> userProfile = _mapper.Map<IEnumerable<UserProfileResponseDTO>>(users);
                userProfile.ToList().ForEach(userProfile => userProfile.Provider = _userManager.GetLoginsAsync(users.Where(user => user.Id == userProfile.UserId).Single()).GetAwaiter().GetResult().FirstOrDefault()?.LoginProvider);
                return Ok(userProfile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            try
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(userLoginRequestDTO.Email);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult signIn = await _signInManager.PasswordSignInAsync(user, userLoginRequestDTO.Password, false, false);

                    if (signIn.Succeeded)
                    {
                        IEnumerable<string> roles = await _userManager.GetRolesAsync(user);
                        UserLoginResponseDTO userLoginResponseDTO = new()
                        {
                            Token = AuthHelper.GenerateToken(user, roles.First(), _configuration)
                        };
                        return Ok(userLoginResponseDTO);
                    }
                    return BadRequest(new { title = "Invalid", message = "Invalid login details. Please try again." });
                }
                else
                {
                    return BadRequest(new { title = "Invalid", message = "Invalid login details. Please try again." });
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //[HttpPost("PreUserSignUp")]
        //public async Task<IActionResult> PreUserSignUp(UserSignUpRequestDTO userSignUpRequestDTO)
        //{
        //    try
        //    {
        //        ApplicationUser? user = await userManager.FindByEmailAsync(userSignUpRequestDTO.Email);
        //        var userStateResponseDTO = new UserStateResponseDTO();
        //        if (user != null)
        //        {
        //            var signIn = await signManager.PasswordSignInAsync(user, userSignUpRequestDTO.Password, false, false);
        //            if (signIn != null && signIn.Succeeded)
        //            {
        //                string jwtToken = await authService.GenerateToken(user);

        //                userStateResponseDTO.State = PreSignupEnum.login.ToString();
        //                userStateResponseDTO.Token = jwtToken;
        //            }
        //            else
        //            {
        //                userStateResponseDTO.State = PreSignupEnum.password.ToString();
        //                userStateResponseDTO.UserProfile = new UserProfileResponseDTO()
        //                {
        //                    UserId = user.Id,
        //                    Email = user.Email,
        //                    Name = user.FirstName,
        //                    Provider = userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider,
        //                    Avatar = user.Avatar
        //                };
        //            }
        //        }
        //        else
        //        {
        //            userStateResponseDTO.State = PreSignupEnum.signup.ToString();
        //        }
        //        return Ok(userStateResponseDTO);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequestDTO signupRequestDTO)
        {
            try
            {
                ApplicationUser? user = _mapper.Map<ApplicationUser>(signupRequestDTO);

                if (signupRequestDTO.IsExternal)
                {
                    switch (signupRequestDTO.ExternalUserAuth?.Provider)
                    {
                        case "GOOGLE":
                            {
                                GoogleJsonWebSignature.Payload? payload = await AuthHelper.VerifyGoogleToken(signupRequestDTO.ExternalUserAuth, _configuration);

                                if (payload != null)
                                {
                                    UserLoginInfo info = new(signupRequestDTO.ExternalUserAuth.Provider.ToString(), payload.Subject, signupRequestDTO.ExternalUserAuth.Provider.ToString());
                                    user.Avatar = payload.Picture;
                                    await _userManager.CreateAsync(user);
                                    await _userManager.AddToRoleAsync(user, RoleEmum.User.ToString());
                                    await _signInManager.SignInAsync(user, false);
                                    await _userManager.AddLoginAsync(user, info);
                                }
                            }
                            break;
                    }
                }
                else
                {
                    await _userManager.CreateAsync(user, signupRequestDTO.Password);
                    await _userManager.AddToRoleAsync(user, RoleEmum.User.ToString());
                    await _signInManager.SignInAsync(user, false);
                }

                string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                EmailConfigurationModel emailConfiguration = _configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
                EmailMessageModel message = AuthHelper.GenerateEmailVerificationEmailMessage(user.Email, user.FirstName, token, _environment.ContentRootPath, _configuration.GetValue<string>("Link"));
                await _emailService.SendEmailAsync(message, emailConfiguration);
                UserLoginResponseDTO userLoginResponseDTO = new()
                {
                    Token = AuthHelper.GenerateToken(user, RoleEmum.User.ToString(), _configuration)
                };
                return Ok(userLoginResponseDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("UserExternalAuth")]
        public async Task<IActionResult> UserExternalAuth(UserExternalAuthRequestDTO userExternalAuthRequestDTO)
        {
            try
            {
                if (userExternalAuthRequestDTO.Provider == ProviderEnum.GOOGLE.ToString())
                {
                    GoogleJsonWebSignature.Payload? payload = await AuthHelper.VerifyGoogleToken(userExternalAuthRequestDTO, _configuration);

                    if (payload != null)
                    {
                        UserLoginInfo info = new(userExternalAuthRequestDTO.Provider.ToString(), payload.Subject, userExternalAuthRequestDTO.Provider.ToString());
                        ApplicationUser? user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                        if (user == null)
                        {
                            user = await _userManager.FindByEmailAsync(payload.Email);
                            if (user == null)
                            {
                                UserStateResponseDTO userState = new()
                                {
                                    State = UserState.signup
                                };

                                return Ok(userState);
                            }
                            else
                            {
                                UserProfileResponseDTO userProfile = _mapper.Map<UserProfileResponseDTO>(user);
                                userProfile.Provider = _userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider;
                                UserStateResponseDTO userState = new()
                                {
                                    State = UserState.password,
                                    UserProfile = userProfile
                                };

                                return Ok(userState);
                            }
                        }
                        else
                        {

                            IEnumerable<string> roles = await _userManager.GetRolesAsync(user);

                            UserStateResponseDTO userState = new()
                            {
                                State = UserState.login,
                                Token = AuthHelper.GenerateToken(user, roles.First(), _configuration)
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

        //[HttpPost("ExternalSignUp")]
        //public async Task<IActionResult> ExternalSignUp([FromBody] SignupRequestDTO signupRequestDTO)
        //{
        //    try
        //    {
        //        if (signupRequestDTO.ExternalUserAuth!.Provider == ProviderEnum.GOOGLE.ToString())
        //        {
        //            GoogleJsonWebSignature.Payload? payload = await AuthHelper.VerifyGoogleToken(signupRequestDTO.ExternalUserAuth, _configuration);

        //            if (payload != null)
        //            {
        //                UserLoginInfo info = new(signupRequestDTO.ExternalUserAuth.Provider, payload.Subject, signupRequestDTO.ExternalUserAuth.Provider);
        //                ApplicationUser? user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
        //                if (user == null)
        //                {
        //                    user = await _userManager.FindByEmailAsync(payload.Email);
        //                    if (user == null)
        //                    {
        //                        user = _mapper.Map<ApplicationUser>(signupRequestDTO);
        //                        user.Avatar = payload.Picture;

        //                        await _userManager.CreateAsync(user);
        //                        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //                        EmailConfigurationModel emailConfiguration = _configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
        //                        EmailMessageModel message = AuthHelper.GenerateEmailVerificationEmailMessage(user.Email, user.FirstName, token, _environment.ContentRootPath, _configuration.GetValue<string>("Link"));
        //                        await _emailService.SendEmailAsync(message, emailConfiguration);
        //                        await _userManager.AddToRoleAsync(user, RoleEmum.User.ToString());
        //                        await _userManager.AddLoginAsync(user, info);

        //                        string jwtToken = AuthHelper.GenerateToken(user, RoleEmum.User.ToString(), _configuration);

        //                        return Ok(jwtToken);
        //                    }
        //                }
        //            }
        //        }
        //        return BadRequest();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpGet("SendResetPasswordMail/{email}")]
        public async Task<IActionResult> SendResetPasswordMail(string email)
        {
            try
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Ok(false);
                }
                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
                EmailConfigurationModel emailConfiguration = _configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
                EmailMessageModel message = AuthHelper.GenerateResetPasswordEmailMessage(user.Email, user.FirstName, token, _environment.ContentRootPath, _configuration.GetValue<string>("Link"));
                await _emailService.SendEmailAsync(message, emailConfiguration);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] EmailWithTokenRequestDTO confirmEmailRequestDTO)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(confirmEmailRequestDTO.Email);
            if (user != null)
            {
                IdentityResult result = await _userManager.ConfirmEmailAsync(user, confirmEmailRequestDTO.Token);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet("VerifyResetPassword")]
        public async Task<IActionResult> VerifyResetPassword([FromQuery] EmailWithTokenRequestDTO verifyResetPasswordRequestDTO)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(verifyResetPasswordRequestDTO.Email);
            if (user != null)
            {
                bool isTokenValid = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", verifyResetPasswordRequestDTO.Token);
                if (isTokenValid)
                {
                    VerifyResetPasswordResponseDTO userAuth = _mapper.Map<VerifyResetPasswordResponseDTO>(user);
                    return Ok(userAuth);
                }
                BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO resetPasswordRequestDTO)
        {
            try
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(resetPasswordRequestDTO.Email);
                Microsoft.AspNetCore.Identity.SignInResult PasswordResult = await _signInManager.CheckPasswordSignInAsync(user, resetPasswordRequestDTO.NewPassword, true);
                if (PasswordResult.Succeeded)
                {
                    return BadRequest(new { title = "Invalid", message = "Your new password cannot be the same as the old password." });
                }
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetPasswordRequestDTO.Token, resetPasswordRequestDTO.NewPassword);

                if (result.Succeeded)
                {
                    IEnumerable<string> roles = await _userManager.GetRolesAsync(user);
                    UserLoginResponseDTO userLoginResponseDTO = new()
                    {
                        Token = AuthHelper.GenerateToken(user, roles.First(), _configuration)
                    };
                    return Ok(userLoginResponseDTO);
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