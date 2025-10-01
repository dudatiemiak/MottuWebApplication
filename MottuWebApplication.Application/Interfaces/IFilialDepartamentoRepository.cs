using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFilialDepartamentoRepository
    {
        Task<IEnumerable<FilialDepartamento>> GetAllAsync();
        Task<FilialDepartamento?> GetByIdAsync(int id);
        Task CreateAsync(FilialDepartamento filialDepartamento);
        Task<bool> UpdateAsync(int id, FilialDepartamento filialDepartamentoIn);
        Task<bool> DeleteAsync(int id);
    }
}
