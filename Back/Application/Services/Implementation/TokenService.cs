using Application.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _secretKey = Encoding.UTF8.GetBytes("my_secret_key");

        #region jwt
        //public async Task<string> GenerateJWTAsync(string username, string userlevel)
        //{
        //    var securityKey = new SymmetricSecurityKey(_secretKey);
        //    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //     {
        //        new Claim(ClaimTypes.Name, username),
        //        new Claim(ClaimTypes.Role, userlevel)
        //     };

        //    var token = new JwtSecurityToken(
        //        issuer: "Orpheus_issuer",
        //        audience: "Orpheus_audiance",
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(1),
        //        signingCredentials: signingCredentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        public async Task<string> GenerateJWTAsync(string username, string userlevel)
        {
            var securityKey = new SymmetricSecurityKey(_secretKey);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
             {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, userlevel)
     };

            var header = new JwtHeader(signingCredentials);
            header.Add("kid", Guid.NewGuid().ToString());

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Orpheus_issuer",
                Audience = "Orpheus_audiance",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }





        public async Task<bool> ValidateJWTAsync(string jwt, string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> CallValidateJWTAsync(string jwt)
        {
            return await ValidateJWTAsync(jwt, Encoding.ASCII.GetString(_secretKey));
        }


        #endregion
    }
}


