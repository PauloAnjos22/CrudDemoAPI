using CrudDemoAPI.Data;
using CrudDemoAPI.Entities;
using CrudDemoAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CrudDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            //_mapper.Map<Classe destino>(Objeto)
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(customers));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerCreateDTO customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == customer.Email);

            if (existingCustomer != null)
                return Conflict("Um usuário com este e-mail já existe");
            else
            {
                var customerMapped = _mapper.Map<Customer>(customer);
                _context.Customers.Add(customerMapped);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCustomers", new { id = customerMapped.Id }, customerMapped);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, CustomerDTO customer)
        {
            if(id != customer.Id)
            {
                return BadRequest();
            }
            _context.Entry(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
