namespace CrudDemoAPI.Interfaces
{
    public interface ICrudService<TCreateDto, TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
    }
}
