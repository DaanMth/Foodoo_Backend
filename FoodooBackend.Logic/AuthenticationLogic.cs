using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using AuthenticationService.Managers;
using FoodooBackend.Models;
using Microsoft.IdentityModel.Tokens;

namespace FoodooBackend.Logic
{
    public class AuthenticationLogic
    {
        public static string key = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        //Makes token
        public static string GenerateToken(string id, string username, string mail)
        {
            IAuthContainerModel model = GetJWTContainerModel(id, username, mail);
            IAuthService authService = new JWTService(model.SecretKey);
    
            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
            {
                throw new UnauthorizedAccessException();
            }

            return token;
        }
        
        public static bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audience in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // The same key as the one that generate the token
            };
        }

        public static JWTContainerModel GetJWTContainerModel(string id, string name, string mail)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, mail)
                }
            };
        }

        public static Account getAccountInfo(string token)
        {
            IAuthService authService = new JWTService(key);
            List<Claim> claims = authService.GetTokenClaims(token).ToList();

            Account viewAccount = new Account
            {
                Username = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name))?.Value,
                Email = claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email))?.Value
            };
            
            return viewAccount;
        }
    }
}
