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
            IEnumerable<string> roles = await userManager.GetRolesAsync(user);
            List<Claim> claims = new()
            {
                new("roles",  roles.FirstOrDefault() ?? string.Empty),
                new("userId",  user.Id.ToString()),
                new("name", user.FirstName),
                new("email", user.Email)
            };

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!));

            JwtSecurityToken token = new(
                issuer: configuration["JwtSettings:ValidIssuer"],
                audience: configuration["JwtSettings:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(UserExternalAuthRequestDTO userExternalAuth)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new()
            {
                // Change this to your google client ID
                Audience = new List<string>() { configuration.GetValue<string>("Authentication:Google:ClientId") }
            };

            // Syncronize my local time with google server...(as the time difference is 1sec so it throws error.)
            await Task.Delay(1000);

            GoogleJsonWebSignature.Payload? payload = await GoogleJsonWebSignature.ValidateAsync(userExternalAuth.TokenId, settings);

            return payload;
        }
    }
}
