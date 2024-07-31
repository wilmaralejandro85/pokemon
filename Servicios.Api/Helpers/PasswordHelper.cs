using Microsoft.IdentityModel.Tokens;
using Servicios.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.

namespace Servicios.Api.Helpers
{

    public class PasswordHelper : IPasswordHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IEncryptHelper _encryptHelper;
        private readonly ILogger _logger;

        public PasswordHelper(ILogger<PasswordHelper> logger, IEncryptHelper _encryptHelper, IConfiguration configuration)
        {
            this._logger = logger;
            this._encryptHelper = _encryptHelper;
            this._configuration = configuration;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public bool ValidateToken(string token, out Guid userId, out string userRoles)
        {
            // default userId 00000000-0000-0000-0000-000000000000
            userId = new Guid();
            userRoles = "";

            if (string.IsNullOrEmpty(token) == true)
            {
                return false;
            }

            SecurityToken? validToken = null;
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                // get key from appsettings and decript it.
                string jwtKey = this._configuration.GetValue<string>("JwtConfig:Secret");
                jwtKey = Task.Run(() => _encryptHelper.DecryptText(jwtKey)).GetAwaiter().GetResult().data;

                var key = Encoding.ASCII.GetBytes(jwtKey);

                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                    // Add any other validations: issuer, audience, lifetime, etc
                };


                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validToken);
                JwtSecurityToken? validJwt = validToken as JwtSecurityToken;
                if (validJwt == null)
                {
                    return false;
                }

                // asign the User id
                userId = Guid.Parse(validJwt.Claims.First(t => t.Type == "id").Value);

                // asign roles
                userRoles = validJwt.Claims.First(t => t.Type == "roles").Value;

                // pass all validations
                return true;

            }
            catch (SecurityTokenExpiredException ex)
            {
                string expired = (validToken is not null) ? validToken.ValidTo.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss") : DateTime.Now.ToString();
                this._logger.LogInformation($"token expired: {expired} and message: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error validating token {ex.Message}");
                return false;
            }
        }


    }
}

#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
