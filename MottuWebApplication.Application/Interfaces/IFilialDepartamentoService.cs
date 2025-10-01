using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFilialDepartamentoService
    {
        Task<IEnumerable<FilialDepartamento>> GetAllFilialDepartamentosAsync();
        Task<FilialDepartamento?> GetFilialDepartamentoByIdAsync(int id);
        Task CreateFilialDepartamentoAsync(FilialDepartamento newFilialDepartamento);
        Task<bool> UpdateFilialDepartamentoAsync(int id, FilialDepartamento updatedFilialDepartamento);
        Task<bool> DeleteFilialDepartamentoAsync(int id);
    }
}
