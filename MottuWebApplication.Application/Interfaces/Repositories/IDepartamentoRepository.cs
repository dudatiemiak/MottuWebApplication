using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<IReadOnlyList<Departamento>> GetAllAsync();
        Task<Departamento?> GetByIdAsync(int id);
        Task<Departamento> CreateAsync(Departamento entity);
        Task UpdateAsync(Departamento entity);
        Task<bool> DeleteAsync(int id);
    }
}
