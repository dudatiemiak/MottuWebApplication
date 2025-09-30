using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IEstadoRepository
    {
        Task<IReadOnlyList<Estado>> GetAllAsync();
        Task<Estado?> GetByIdAsync(int id);
        Task<Estado> CreateAsync(Estado entity);
        Task UpdateAsync(Estado entity);
        Task<bool> DeleteAsync(int id);
    }
}
