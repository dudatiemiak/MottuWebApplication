using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetAllAsync();
        Task<Modelo?> GetByIdAsync(int id);
        Task CreateAsync(Modelo modelo);
        Task<bool> UpdateAsync(int id, Modelo modeloIn);
        Task<bool> DeleteAsync(int id);
    }
}
