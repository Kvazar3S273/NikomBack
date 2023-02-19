using Data.Nikom.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nikom.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace Nikom.Services
{
    public interface IJwtConfig
    {
        public string CreateToken(AppUser user);
    }
    public class JwtConfig : IJwtConfig
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<AppUser> _userManager;
        public JwtConfig(IOptions<AppSettings> appsettings, UserManager<AppUser> userManager)
        {
            _appSettings = appsettings.Value;
            _userManager = userManager;
        }
        public string CreateToken(AppUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var roleClaims = new List<Claim>()
            {
                 new Claim("id",user.Id.ToString()),
                 new Claim("name",user.UserName),
                 new Claim("email",user.Email)
            };
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var signKey = new SymmetricSecurityKey(key);
            var singCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
               signingCredentials: singCredentials,
               expires: DateTime.Now.AddDays(1),
               claims: roleClaims
               );
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }
    }
}
