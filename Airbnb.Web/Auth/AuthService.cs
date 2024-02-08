using Airbnb.Model.CustomModels;
using Airbnb.Model.DTO.Request;
using Airbnb.Model.Models;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Airbnb.Web.Auth
{
    public class AuthService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var userAuth = new UserAuthModel()
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Avatar = user.Avatar,
                Role = await userManager.GetRolesAsync(user)
            };

            var authClaims = new List<Claim>()
            {
                new("Roles",  userAuth.Role.First().ToString()),
                new("userId",  userAuth.UserId.ToString()),
                new("name", userAuth.FirstName),
                new("email", userAuth.Email),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:ValidIssuer"],
                audience: configuration["JwtSettings:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(UserExternalAuthRequestDTO userExternalAuth)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            // Change this to your google client ID
            settings.Audience = new List<string>() { configuration.GetValue<string>("Authentication:Google:ClientId") };

            // Syncronize my local time with google server...(as the time difference is 1sec so it throws error.)
            await Task.Delay(1000);

            GoogleJsonWebSignature.Payload? payload = GoogleJsonWebSignature.ValidateAsync(userExternalAuth.TokenId, settings).Result;

            return payload;
        }
    }
}
