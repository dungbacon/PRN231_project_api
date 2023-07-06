using e_commerce_app_api.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_commerce_app_api.Config
{
    public class JwtConfig
    {
        public static string CreateToken(AccountDTO account, IConfiguration config)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Email", account.Email.ToString()),
                new Claim("Role", account.Role.RoleDesc.ToString()),
            };
            var token = new JwtSecurityToken(
                    config["JWT:Issuer"],
                    config["JWT:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool IsValidToken(string token)
        {
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
            }
            catch (Exception)
            {
                return false;
            }
            return jwtSecurityToken.ValidTo > DateTime.UtcNow;
        }

    }
}
