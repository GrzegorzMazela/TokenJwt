using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using TokenJwt.Dto;

namespace TokenJwt.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private List<UserDto> Users { get; set; }

        private IConfiguration ConfigurationRoot { get; set; }
        private ILogger<TokenController> Logger { get; set; }


        public TokenController(IConfiguration configurationRoot, ILogger<TokenController> logger)
        {
            ConfigurationRoot = configurationRoot;
            Logger = logger;
            Users = new List<UserDto>();
            Users.Add(new Dto.UserDto
            {
                Email = "test@test.pl",
                Passwoerd = "qwer1234",
                UserId = "1",
                UserName = "testUser"
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = Users.FirstOrDefault(x => x.Email == loginDto.Email);
                if (user == null)
                {
                    return Unauthorized();
                }

                if (user.Passwoerd == loginDto.Passwoerd)
                {

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, user.UserId),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    };

                    var symetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                        ConfigurationRoot["JwtToken:Key"]));
                    var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

                    var jwtToken = new JwtSecurityToken(
                        issuer: ConfigurationRoot["JwtToken:Issuer"],
                        audience: ConfigurationRoot["JwtToken:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: signingCredentials
                        );

                    return Ok(new TokenDto(new JwtSecurityTokenHandler().WriteToken(jwtToken), jwtToken.ValidTo));
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}