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
    public class EmployeeController : ControllerBase
    {
        private EmployeeSC employeeSC = new();

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employees = employeeSC.GetAll().Select(s => new EmployeeDTO
                {
                    Name = s.FirstName,
                    FamilyName = s.LastName,
                    Tag = s.Title,
                    Address = s.Address
                }).ToList();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var employee = employeeSC.Get(id);
                var castEmployee = new EmployeeDTO
                {
                    Name = employee.FirstName,
                    FamilyName = employee.LastName,
                    Tag = employee.Title,
                    Address = employee.Address

                };
                return Ok(castEmployee);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDTO newEmployee)
        {
            try
            {
                employeeSC.Add(newEmployee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeDTO employeeUpdated)
        {
            try
            {
                employeeSC.Update(id, employeeUpdated);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                employeeSC.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
