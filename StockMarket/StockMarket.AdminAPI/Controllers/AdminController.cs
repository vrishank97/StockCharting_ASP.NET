using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarket.AdminAPI.Models;
using StockMarket.AdminAPI.Services;

namespace StockMarket.AdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class AdminController : ControllerBase
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Admin Service");
        }

        [HttpPost]
        [Route("Companies/Add")]
        public IActionResult AddCompany(Company company)
        {

            try
            {
                service.AddCompany(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Companies/All")]
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

        [HttpPost]
        [Route("IPOS/Add")]
        public IActionResult AddIPO(IPODetails ipo)
        {

            try
            {
                service.AddIPO(ipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("IPOS/All")]
        public IActionResult GetAllIPOS()
        {

            try
            {
                return Ok(service.GetAllIPOS());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Companies/Update")]
        public IActionResult UpdateCompany(Company company)
        {
            try
            {
                service.UpdateCompany(company);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("IPOS/Update")]
        public IActionResult UpdateIPO(IPODetails ipo)
        {
            try
            {
                service.UpdateIPO(ipo);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("IPOS/Delete")]
        public IActionResult DeleteIPO(string id)
        {
            try
            {
                service.DeleteIPO(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Companies/Delete")]
        public IActionResult DeleteCompany(string id)
        {
            try
            {
                service.DeleteCompany(id);
                return Ok();
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
    }
}
