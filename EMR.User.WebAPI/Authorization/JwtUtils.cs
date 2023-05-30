using EMR.Data.Model.Settings;
using EMR.Data.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMR.WebAPI.Authorization
{
    public class JwtUtils : IJwtUtils
    {
        private readonly AppSettings _appSettings;

        public JwtUtils(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Generate JWT Auth Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(UserDetailModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Authorization.Secret);
            var claims = GetTokenClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(_appSettings.Authorization.Expiration),
                Issuer = _appSettings.Authorization.Issuer,
                Audience = _appSettings.Authorization.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public UserDetailModel? ValidateToken(string token)
        {
            if (token == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Authorization.Secret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _appSettings.Authorization.Issuer,
                    ValidAudience = _appSettings.Authorization.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Authorization.Secret)),
                    ClockSkew = TimeSpan.FromMinutes(1)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;                
                return GetUserDetailModel(jwtToken);
            }
            catch
            {
                return null;
            }
        }

        private IEnumerable<Claim> GetTokenClaims(UserDetailModel user)
        {
            var claims = new List<Claim>();
            IdentityOptions options = new IdentityOptions();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.EmailAddress));
            claims.Add(new Claim(options.ClaimsIdentity.UserIdClaimType, user.UserDetailId.ToString()));
            claims.Add(new Claim(options.ClaimsIdentity.UserNameClaimType, string.Join(".", user.FirstName, user.LastName)));
            claims.Add((new Claim(options.ClaimsIdentity.EmailClaimType, user.EmailAddress)));
            claims.Add((new Claim(options.ClaimsIdentity.RoleClaimType, user.UserRoleId.ToString())));

            return claims;
        }

        private UserDetailModel GetUserDetailModel(JwtSecurityToken token)
        {
            IdentityOptions options = new IdentityOptions();
            var userName = token.Claims.First(x => x.Type == options.ClaimsIdentity.UserNameClaimType).Value;

            var user = new UserDetailModel {
                UserDetailId = Guid.Parse(token.Claims.First(x => x.Type == options.ClaimsIdentity.UserIdClaimType).Value),
                FirstName = userName.Split(".")[0],
                LastName = userName.Split(".")[1],
                EmailAddress= token.Claims.First(x => x.Type == options.ClaimsIdentity.EmailClaimType).Value,
                UserRoleId = Convert.ToInt32(token.Claims.First(x => x.Type == options.ClaimsIdentity.RoleClaimType).Value)
            };

            return user;
        }
    }
}
