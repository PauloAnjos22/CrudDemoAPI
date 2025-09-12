using CrudDemoAPI.DTOs;
using CrudDemoAPI.Interfaces;
using CrudDemoAPI.Data;
using CrudDemoAPI.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CrudDemoAPI.Services
{
    public class CustomerService : ICrudService<CustomerCreateDTO, CustomerDTO>
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

    }
}
