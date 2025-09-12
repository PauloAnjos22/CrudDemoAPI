using AutoMapper;
using CrudDemoAPI.Data;
using CrudDemoAPI.DTOs;
using CrudDemoAPI.Entities;
using CrudDemoAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using CrudDemoAPI.Services;

namespace CrudDemoAPI.Services
{
    public class CustomerService : ICrudService<CustomerCreateDTO, CustomerUpdateDTO, CustomerDTO>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            //_mapper.Map<Classe destino>(Objeto)
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO?> GetByIdAsync(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            //return customer is null ? null : _mapper.Map<CustomerDTO>(customer);
            return _mapper.Map<CustomerDTO>(customer); // o AutoMapper já retorna null se customer for null :)
        }
        public async Task<CustomerDTO?> CreateAsync(CustomerCreateDTO customerCreateDto)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customerCreateDto.Email);

            if (existingCustomer != null)
            {
                return null;
                //throw new InvalidOperationException("Um usuário com este e-mail já existe"); (implementar exception middleware)
            }
            else
            {
                var customerMapped = _mapper.Map<Customer>(customerCreateDto);

                _context.Customers.Add(customerMapped);
                await _context.SaveChangesAsync();

                var customerToReturn = _mapper.Map<CustomerDTO>(customerMapped);
                return customerToReturn;
            }
        }
        public async Task<ServiceResult> UpdateAsync(long id, CustomerUpdateDTO CustomerDto)
        {
            if (id != CustomerDto.Id)
            {
                return ServiceResult.Fail("ValidationError");
            }
            _context.Entry(_mapper.Map<Customer>(CustomerDto)).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return ServiceResult.Fail("NotFound");
                }
                else
                {
                    throw;
                }
            }
            return ServiceResult.Ok();
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        public async Task<ServiceResult> DeleteAsync(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return ServiceResult.Fail("NotFound");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return ServiceResult.Ok();
        }
    }
}
