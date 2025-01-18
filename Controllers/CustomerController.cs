using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleCoreRestfulAPI.Dtos;
using SampleCoreRestfulAPI.Interfaces;

namespace SampleCoreRestfulAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerRequestDto createCustomerRequestDto)
        {            
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(new { Errors = errors });
            }
            return Ok(await customerService.CreateCustomerAsync(createCustomerRequestDto));
        }

        [HttpGet("{id:Guid?}")]
        public async Task<IActionResult> GetCustomer(Guid? id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }
            return Ok(customer);
        }
    }
}