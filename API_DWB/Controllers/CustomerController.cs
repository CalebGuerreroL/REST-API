using DatabaseFirst_DWB.Models;
using DatabaseFirst_DWB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_DWB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerSC customerSC = new();
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customers = customerSC.GetAll().Select(s => new CustomerDTO
                {
                    Identifier = s.CustomerId,
                    Company = s.CompanyName,
                    Contact = s.ContactName,
                    Title = s.ContactTitle,
                    PhoneNumber = s.Phone
                }).ToList();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var customer = customerSC.Get(id);
                var castCustomer = new CustomerDTO
                {
                    Identifier = customer.CustomerId,
                    Company = customer.CompanyName,
                    Contact = customer.ContactName,
                    Title = customer.ContactTitle,
                    PhoneNumber = customer.Phone
                };
                return Ok(castCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDTO newCustomer)
        {
            try
            {
                customerSC.Add(newCustomer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CustomerDTO customerUpdated)
        {
            try
            {
                customerSC.Update(id, customerUpdated);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                customerSC.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
