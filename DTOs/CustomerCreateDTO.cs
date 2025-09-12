using System.ComponentModel.DataAnnotations;

namespace CrudDemoAPI.DTOs
{
    public class CustomerCreateDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
