using AutoMapper;
using CrudDemoAPI.DTOs;
using CrudDemoAPI.Entities;

namespace CrudDemoAPI.AutoMapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
