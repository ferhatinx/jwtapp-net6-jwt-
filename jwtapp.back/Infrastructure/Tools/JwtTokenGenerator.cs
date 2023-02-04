using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using jwtapp.back.Core.Application.Dto;
using Microsoft.IdentityModel.Tokens;

namespace jwtapp.back.Infrastructure.Tools
{
    public static class JwtTokenGenerator
    {
        public static TokenResponseDto GenereateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }
            claims.Add(new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()));
            if(!string.IsNullOrEmpty(dto.Username))
                claims.Add(new Claim("Username",dto.Username));

            var securitykey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentials = new(securitykey,SecurityAlgorithms.HmacSha256);
            
            var expireDate  = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new(issuer:JwtTokenDefaults.ValidIssuer,
            audience:JwtTokenDefaults.ValidAudience,
            claims:null,notBefore:DateTime.UtcNow, 
            expires: expireDate,
            signingCredentials:null);

            JwtSecurityTokenHandler handler = new();
            // handler.WriteToken()
            return new TokenResponseDto(handler.WriteToken(token),expireDate);
        }
    }
}