using System.ComponentModel.DataAnnotations;

namespace CrudDemoAPI.DTOs
{
    public class CustomerDTO 
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
