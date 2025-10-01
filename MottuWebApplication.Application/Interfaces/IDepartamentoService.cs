using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<Departamento>> GetAllDepartamentosAsync();
        Task<Departamento?> GetDepartamentoByIdAsync(int id);
        Task CreateDepartamentoAsync(Departamento newDepartamento);
        Task<bool> UpdateDepartamentoAsync(int id, Departamento updatedDepartamento);
        Task<bool> DeleteDepartamentoAsync(int id);
    }
}
