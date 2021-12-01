using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AuthenticationService.Managers;
using FoodooBackend.Models;

namespace FoodooBackend.Logic
{
    public class AuthenticationLogic
    {
        //Makes token
        public static string GenerateToken(string username, string mail)
        {
            IAuthContainerModel model = GetJWTContainerModel(username, mail);
            IAuthService authService = new JWTService(model.SecretKey);
    
            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
            {
                throw new UnauthorizedAccessException();
            }

            return token;
        }

        public static JWTContainerModel GetJWTContainerModel(string name, string mail)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, mail)
                }
            };
        }

        public string GetUsername(string token)
        {
            string sk = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";//Environment.GetEnvironmentVariable("SecretKeyNl");
            IAuthService authService = new JWTService(sk);
            List<Claim> claims = authService.GetTokenClaims(token).ToList();

            return claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name))?.Value;
            //Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name))?.Value);
            //Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email))?.Value);
        }
    }
}
