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
    public class ProductController : ControllerBase
    {
        private ProductSC productSC = new();
        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = productSC.GetAll().Select(s => new ProductDTO
                {
                    Product = s.ProductName,
                    Price = s.UnitPrice,
                    QuantityPerProduct = s.QuantityPerUnit,
                    InStock = s.UnitsInStock
                }).ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = productSC.Get(id);
                var castProduct = new ProductDTO
                {
                    Product = product.ProductName,
                    Price = product.UnitPrice,
                    QuantityPerProduct = product.QuantityPerUnit,
                    InStock = product.UnitsInStock
                };
                return Ok(castProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO newProduct)
        {
            try
            {
                productSC.Add(newProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO productUpdated)
        {
            try
            {
                productSC.Update(id, productUpdated);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                productSC.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
