using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IModeloRepository
    {
        Task<IReadOnlyList<Modelo>> GetAllAsync();
        Task<Modelo?> GetByIdAsync(int id);
        Task<Modelo> CreateAsync(Modelo entity);
        Task UpdateAsync(Modelo entity);
        Task<bool> DeleteAsync(int id);
    }
}
