using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IEstadoService
    {
        Task<IEnumerable<Estado>> GetAllEstadosAsync();
        Task<Estado?> GetEstadoByIdAsync(int id);
        Task CreateEstadoAsync(Estado newEstado);
        Task<bool> UpdateEstadoAsync(int id, Estado updatedEstado);
        Task<bool> DeleteEstadoAsync(int id);
    }
}
