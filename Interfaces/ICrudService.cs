using CrudDemoAPI.Services;

using Microsoft.AspNetCore.Mvc;

namespace CrudDemoAPI.Interfaces
{
    public interface ICrudService<TCreateDto, TUpdateDTO, TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(long id);
        Task<TDto?> CreateAsync(TCreateDto dto);
        Task<ServiceResult> UpdateAsync(long id, TUpdateDTO dto);
        Task<ServiceResult> DeleteAsync(long id);
    }
}
