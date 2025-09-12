using System.ComponentModel.DataAnnotations;

namespace CrudDemoAPI.DTOs
{
    public class CustomerUpdateDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
