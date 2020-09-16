using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockMarket.AccountAPI.Models;
using StockMarket.AccountAPI.Services;
namespace StockMarket.AccountAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class AccountController : ControllerBase
    {
        private IAccountService service;
        private readonly IConfiguration configuration;

        public AccountController(IAccountService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Account Service");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("Status")]
        public IActionResult IsUp()
        {
            return Ok("Account Service");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Validate/{uname}/{pwd}")]
        public IActionResult Validate(string uname, string pwd)
        {
            try
            {
                if(uname=="Admin" && pwd == "123")
                {
                    return Ok(GenerateJwtToken(uname));
                }
                User user = service.Validate(uname, pwd);
                if (user == null)
                {
                    return Content("Invalid User");
                }
                else
                {
                    return Ok(GenerateJwtToken(uname));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User item)
        {

            try
            {
                service.AddUser(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        [Route("All")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(service.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private Token GenerateJwtToken(string uname)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, uname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, uname),
                new Claim(ClaimTypes.Role,uname)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var response = new Token
            {
                uname = uname,
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return response;
        }
    }
}
