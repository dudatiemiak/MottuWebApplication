using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _repo;
        public EstadoService(IEstadoRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Estado>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Estado?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Estado> CreateAsync(Estado entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Estado entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
