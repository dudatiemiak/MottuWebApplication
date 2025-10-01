using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(int id);
        Task CreateAsync(Departamento departamento);
        Task<bool> UpdateAsync(int id, Departamento departamentoIn);
        Task<bool> DeleteAsync(int id);
    }
}
