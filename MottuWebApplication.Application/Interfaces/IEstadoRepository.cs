using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<Estado>> GetAllAsync();
        Task<Estado?> GetByIdAsync(int id);
        Task CreateAsync(Estado estado);
        Task<bool> UpdateAsync(int id, Estado estadoIn);
        Task<bool> DeleteAsync(int id);
    }
}
