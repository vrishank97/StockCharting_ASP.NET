using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.UserAPI.Models;
using StockMarket.UserAPI.Services;

namespace StockMarket.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("User Service");
        }

        [HttpGet]
        [Route("Companies/")]
        public IActionResult GetAllCompanies()
        {

            try
            {
                return Ok(service.GetAllCompanies());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("IPOS/")]
        public IActionResult GetAllIPOS()
        {

            try
            {
                return Ok(service.GetIPOS());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Companies/{id}")]
        public IActionResult GetCompany(string id)
        {
            try
            {
                return Ok(service.GetCompany(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Prices/{companyCode}/{start}/{end}")]
        public IActionResult GetPrices(string companyCode, DateTime start, DateTime end)
        {
            try
            {
                return Ok(service.GetStockPrices(companyCode, start, end));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
