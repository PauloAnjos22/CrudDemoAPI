using CrudDemoAPI.Data;
using CrudDemoAPI.Entities;
using CrudDemoAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CrudDemoAPI.Interfaces;

namespace CrudDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICrudService<CustomerCreateDTO, CustomerUpdateDTO, CustomerDTO> _service;

        public CustomersController(ICrudService<CustomerCreateDTO, CustomerUpdateDTO, CustomerDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customersResult = await _service.GetAllAsync();
            return Ok(customersResult);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(long id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.Success || result.Data == null )
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerCreateDTO customer)
        {

            var customerResponse = await _service.CreateAsync(customer);
            if(customerResponse == null)
            {
                return Conflict("Um usuário com este e-mail já existe.");
            }
            return CreatedAtAction("GetCustomers", new { id = customerResponse.Id }, customerResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, CustomerUpdateDTO customer)
        {
            var updateResult = await _service.UpdateAsync(id, customer);
            if (!updateResult.Success)
            {
               return updateResult.Message switch 
               {
                   "ValidationError" => BadRequest(updateResult.Message),
                    "NotFound" => NotFound(),
                    _ => StatusCode(500, "An unexpected error occurred")
               };
            }
            return NoContent();
        }

        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var deleteResult = await _service.DeleteAsync(id);
            if(!deleteResult.Success)
            {
                return deleteResult.Message switch
                {
                    "NotFound" => NotFound(),
                    _ => StatusCode(500, "An unexpected error occurred")
                };
            }
            return NoContent();
        }

    }
}
