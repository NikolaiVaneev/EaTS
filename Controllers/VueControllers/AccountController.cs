using EaTS.Data;
using EaTS.Models;
using EaTS.Service;
using EaTS.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace EaTS.Controllers.VueControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }
        private readonly ApplicationDbContext _db;

        [HttpPost("/token")]
        public IActionResult Token(LoginRequest request)
        {
            var getIdentityResponse = GetIdentity(request.username, request.password);
            if (getIdentityResponse == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: getIdentityResponse.claimsIdentity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                accessToken = encodedJwt,
                role = getIdentityResponse.user
            };

            return new ObjectResult(response);

        }

        private GetIdentityResponse GetIdentity(string username, string password)
        {
            User user = _db.User.FirstOrDefault(u => u.Login == username && u.Password == password);

            if(user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.GetDescription())
                };

                ClaimsIdentity claimsIdentity = new(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                GetIdentityResponse getIdentityResponse = new GetIdentityResponse
                {
                    claimsIdentity = claimsIdentity,
                    user = user
                };
                return getIdentityResponse;
            }
            // если пользователя не найдено
            return null;

        }

    }
}
