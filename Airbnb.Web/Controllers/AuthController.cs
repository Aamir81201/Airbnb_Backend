using Airbnb.Common.Enum;
using Airbnb.DataModels.Models;
using Airbnb.Repository.Interface;
using Airbnb.ViewModels;
using Airbnb.Web.Auth;
using Airbnb.Web.Services;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly AuthService authService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;


        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.authService = new AuthService(configuration, userManager);
            this.userManager = userManager;
            this.signManager = signManager;
            this.roleManager = roleManager;
        }

        [HttpGet("IsUserExists")]
        public async Task<IActionResult> IsUserExists(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Ok(new UserStateModel() { State = PreSignup.signup.ToString() });
                }
                else
                {
                    return Ok(new UserStateModel()
                    {
                        State = PreSignup.password.ToString(),
                        UserProfile = new UserProfileModel()
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetSavedUsers")]
        public IActionResult GetSavedUsers(List<string> userIds)
        {
            try
            {
                var users = userManager.Users.Where(user => userIds.Contains(user.Id.ToString())).ToList();
                var userProfile = users.Select(user => new UserProfileModel()
                {
                    UserId = user.Id,
                    Name = user.FirstName,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    Provider = userManager.GetLoginsAsync(user).Result.FirstOrDefault()?.LoginProvider,
                }).ToList();
                return Ok(userProfile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginModel userLogin)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(userLogin.Email);
                if (user != null)
                {
                    var signIn = await signManager.PasswordSignInAsync(user, userLogin.Password, false, true);

                    if (signIn.Succeeded)
                    {
                        string jwtToken = await authService.GenerateToken(user);
                        return Ok(jwtToken);
                    }
                }
                return BadRequest("Invalid login details.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("PreUserSignUp")]
        public async Task<IActionResult> PreUserSignUp(UserSignUpModel userSignUp)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(userSignUp.Email);
                if (user != null)
                {
                    var signIn = await signManager.PasswordSignInAsync(user, userSignUp.Password, false, false);
                    if (signIn != null && signIn.Succeeded)
                    {
                        string jwtToken = await authService.GenerateToken(user);

                        var userState = new UserStateModel()
                        {
                            State = PreSignup.login.ToString(),
                            Token = jwtToken
                        };
                        return Ok(userState);
                    }
                    else
                    {
                        var userState = new UserStateModel()
                        {
                            State = PreSignup.password.ToString(),
                            UserProfile = new UserProfileModel()
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
                    var userState = new UserStateModel()
                    {
                        State = PreSignup.signup.ToString()
                    };
                    return Ok(userState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UserSignUp")]
        public async Task<IActionResult> UserSignUp(UserSignUpModel userSignUp)
        {
            try
            {
                var user = new ApplicationUser()
                {
                    UserName = userSignUp.Email,
                    FirstName = userSignUp.FirstName,
                    LastName = userSignUp.LastName,
                    DateOfBirth = userSignUp.DateOfBirth,
                    RecieveMarketingMessages = userSignUp.RecieveMarketingMessages,
                    Email = userSignUp.Email
                };

                var result = await userManager.CreateAsync(user, userSignUp.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Role.User.ToString());
                    await signManager.SignInAsync(user, false);

                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = $"http://localhost:4200?token={token}&email={user.Email}";
                    //var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);
                    var message = new EmailMessage(new string[] { user.Email }, "Confirmation email link", confirmationLink);
                    var emailConfiguration = configuration.GetSection(nameof(EmailConfiguration)).Get<EmailConfiguration>();
                    var emailSender = new EmailSender(emailConfiguration);
                    emailSender.SendEmailAsync(message);

                    string jwtToken = await authService.GenerateToken(user);
                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("PreExternalAuthentication")]
        public async Task<IActionResult> PreExternalAuthentication(UserExternalAuthModel externalAuth)
        {
            try
            {
                if (externalAuth.Provider == Provider.GOOGLE.ToString())
                {
                    GoogleJsonWebSignature.Payload? payload = await authService.VerifyGoogleToken(externalAuth);

                    if (payload != null)
                    {
                        var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);
                        var user = await userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                        if (user == null)
                        {
                            user = await userManager.FindByEmailAsync(payload.Email);
                            if (user == null)
                            {
                                var userState = new UserStateModel()
                                {
                                    State = PreSignup.signup.ToString()
                                };
                                return Ok(userState);
                            }
                            else
                            {
                                var userState = new UserStateModel()
                                {
                                    State = PreSignup.password.ToString(),
                                    UserProfile = new UserProfileModel()
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

                            var userState = new UserStateModel()
                            {
                                State = PreSignup.login.ToString(),
                                Token = jwtToken
                            };
                            return Ok(userState);
                        }
                    }
                }
                return BadRequest("Something Went really wrong");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("ExternalSignUp")]
        public async Task<IActionResult> ExternalSignUp(UserSignUpModel userSignUp)
        {
            try
            {
                if (userSignUp.ExternalUserAuth!.Provider == Provider.GOOGLE.ToString())
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
                                var confirmationLink = $"http://localhost:4200?token={token}&email={user.Email}";
                                var message = new EmailMessage(new string[] { user.Email }, "Confirmation email link", confirmationLink);
                                var emailConfiguration = configuration.GetSection(nameof(EmailConfiguration)).Get<EmailConfiguration>();
                                var emailSender = new EmailSender(emailConfiguration);
                                emailSender.SendEmailAsync(message);
                                await userManager.AddToRoleAsync(user, Role.User.ToString());
                                await userManager.AddLoginAsync(user, info);

                                var jwtToken = await authService.GenerateToken(user);

                                return Ok(jwtToken);
                            }
                        }
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //public async Task<IActionResult> SendConfirmationEmail(ApplicationUser user)
        //{
        //    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);
        //    var message = new EmailMessage(new string[] { user.Email }, "Confirmation email link", confirmationLink);
        //    var emailConfiguration = configuration.GetSection(nameof(EmailConfiguration)).Get<EmailConfiguration>();
        //    var emailSender = new EmailSender(emailConfiguration);
        //    await emailSender.SendEmailAsync(message);
        //    return Ok();
        //}

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email = "sds", string token = "f")
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
    }
}