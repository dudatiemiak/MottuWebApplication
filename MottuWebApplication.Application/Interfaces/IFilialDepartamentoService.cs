using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFilialDepartamentoService
    {
        Task<IReadOnlyList<FilialDepartamento>> GetAllAsync();
        Task<FilialDepartamento?> GetByIdAsync(int id);
        Task<FilialDepartamento> CreateAsync(FilialDepartamento entity);
        Task UpdateAsync(FilialDepartamento entity);
        Task<bool> DeleteAsync(int id);
    }
}
