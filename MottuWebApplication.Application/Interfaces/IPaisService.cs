using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IPaisService
    {
        Task<IReadOnlyList<Pais>> GetAllAsync();
        Task<Pais?> GetByIdAsync(int id);
        Task<Pais> CreateAsync(Pais entity);
        Task UpdateAsync(Pais entity);
        Task<bool> DeleteAsync(int id);
    }
}
