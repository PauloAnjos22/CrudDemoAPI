using CrudDemoAPI.Data;
using CrudDemoAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController (AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == customer.Email);

            if (existingCustomer != null)
                return Conflict("Um usuário com este e-mail já existe");
            else
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return Ok(customer);
                //return CreatedAtAction("GetCustomers", new { id = customer.Id }, customer);
            }
        }
        
    }
}
