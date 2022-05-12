using Api.Data;
using Api.Models;
using Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly SimpleAppDBContext _simpleAppDBContext;

        public AuthService()
        {
            _simpleAppDBContext = new SimpleAppDBContext();
        }

        public string GetAuthenticationToken(WebUser webUser)
        {
            try
            {
                var user = _simpleAppDBContext.Users?.FirstOrDefault(u => u.Email == webUser.Email);
                if (user != null)
                {
                    if (CheckPassword(webUser, user))
                    {
                        return GetTokens(user);
                    }
                }
            }
            catch
            {
                // log error
            }

            return string.Empty;
        }

        public bool RegisterNewUser(WebUser webUser)
        {
            try
            {
                var user = _simpleAppDBContext.Users?.FirstOrDefault(u => u.Email == webUser.Email);

                if (user != null)
                {
                    return false;
                }

                user = new User
                {
                    Email = webUser.Email
                };

                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, webUser.Password);

                _simpleAppDBContext.Add(user);
                var saved = _simpleAppDBContext.SaveChanges();
                
                if (saved > 0)
                {
                    return true;
                }
            }
            catch
            {
                // log error
            }

            return false;
        }

        private bool CheckPassword(WebUser webUser, User user)
        {
            try
            {
                // use salt key along with password for security

                // password check with db
                var passCheck = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, webUser.Password);

                if ((int)passCheck == 1)
                {
                    return true;
                }
            }
            catch
            {
                // log error
            }
            return false;
        }

        private string GetTokens(User user)
        {
            try
            {
                // save these on appsettings.json
                var secutirykey = "simpleappsecuritykey";
                var issuer = "simpleappissuer";
                var audience = "simpleappaudience";

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secutirykey));
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                };

                var jwtToken = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: DateTime.Now.AddDays(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                return token;
            }
            catch
            {
                // log local error
            }
            return string.Empty;
        }
    }
}