namespace CrudDemoAPI.DTOs
{
    public class BaseDTO
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
