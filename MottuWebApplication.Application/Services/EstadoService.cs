using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _repo;
        public EstadoService(IEstadoRepository repo){
            _repo = repo;
        }
        public Task<IEnumerable<Estado>> GetAllEstadosAsync() => _repo.GetAllAsync();
        public Task<Estado?> GetEstadoByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateEstadoAsync(Estado newEstado) => _repo.CreateAsync(newEstado);
        public Task<bool> UpdateEstadoAsync(int id, Estado updatedEstado) => _repo.UpdateAsync(id, updatedEstado);
        public Task<bool> DeleteEstadoAsync(int id) => _repo.DeleteAsync(id);
    }
}
