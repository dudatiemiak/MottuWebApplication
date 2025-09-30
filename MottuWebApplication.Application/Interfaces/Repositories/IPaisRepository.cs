using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IPaisRepository
    {
        Task<IReadOnlyList<Pais>> GetAllAsync();
        Task<Pais?> GetByIdAsync(int id);
        Task<Pais> CreateAsync(Pais entity);
        Task UpdateAsync(Pais entity);
        Task<bool> DeleteAsync(int id);
    }
}
