using Airbnb.Model.CustomModels;
using Airbnb.Model.DTO.Request;
using Airbnb.Model.Models;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Airbnb.Model.Common.HelperMethods
{
    public class AuthHelper
    {
        public static string GenerateToken(ApplicationUser user, string role, IConfiguration _configuration)
        {
            IEnumerable<Claim> claims = new List<Claim>()
            {
                new(ClaimTypes.Role,  role),
                new(ClaimTypes.NameIdentifier,  user.Id.ToString()),
                new(ClaimTypes.Name, user.FirstName),
                new(ClaimTypes.Email, user.Email)
            };

            SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]!));

            JwtSecurityToken token = new(
                issuer: _configuration["JwtSettings:ValidIssuer"],
                audience: _configuration["JwtSettings:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }

        public static async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(UserExternalAuthRequestDTO userExternalAuth, IConfiguration _configuration)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new()
            {
                // Change this to your google client ID
                Audience = new List<string>() { _configuration["Authentication:Google:ClientId"]! }
            };

            // Syncronize my local time with google server...(as the time difference is 1sec so it throws error.)
            await Task.Delay(1000);

            GoogleJsonWebSignature.Payload? payload = await GoogleJsonWebSignature.ValidateAsync(userExternalAuth.TokenId, settings);

            return payload;
        }

        public static EmailMessageModel GenerateResetPasswordEmailMessage(string email, string name, string token, string rootPath, string link)
        {
            UriBuilder url = new($"{link}/reset-password");
            string subject = "Reset your password";

            // Set query parameters
            System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString(url.Query);
            query["token"] = token;
            query["email"] = email;
            url.Query = query.ToString();
            string pathToFile = Path.Combine(rootPath, "AppData/EmailTemplates/EmailResetPasswordTemplate.html");

            BodyBuilder builder = new();

            using (StreamReader sr = new(pathToFile))
            {
                builder.HtmlBody = sr.ReadToEnd();
            }
            string content = string.Format(builder.HtmlBody, name, url);

            return new EmailMessageModel()
            {
                To = new List<MailboxAddress>() { new(name, email) },
                Subject = subject,
                Content = content
            };
        }

        public static EmailMessageModel GenerateEmailVerificationEmailMessage(string email, string name, string token, string rootPath, string link)
        {
            UriBuilder url = new($"{link}/email-verification");
            string subject = "Please confirm your email address";

            // Set query parameters
            System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString(url.Query);
            query["token"] = token;
            query["email"] = email;
            url.Query = query.ToString();
            string pathToFile = Path.Combine(rootPath, "AppData/EmailTemplates/EmailReminderTemplate.html");

            BodyBuilder builder = new();

            using (StreamReader sr = new(pathToFile))
            {
                builder.HtmlBody = sr.ReadToEnd();
            }
            string content = string.Format(builder.HtmlBody, name, url);

            return new EmailMessageModel()
            {
                To = new List<MailboxAddress>() { new(name, email) },
                Subject = subject,
                Content = content
            };
        }
    }
}
