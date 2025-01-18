using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Interfaces;

namespace SampleCoreRestfulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            return Ok(await productService.GetProductsAsync());
        }
        [HttpGet("{id:Guid}")]  
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            return Ok(await productService.GetProductAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequestDto productDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCustomer = await productService.CreateProductAsync(productDto);
            if(createdCustomer == null)
            {
                return BadRequest(new { Error = "Error creating product" });
            }
            //return CreatedAtAction(nameof(GetProductAsync), new { id = createdCustomer.Id }, createdCustomer);
            return Ok(createdCustomer);
        }
    }
}