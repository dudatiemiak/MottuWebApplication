using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _repo;
        public ModeloService(IModeloRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Modelo>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Modelo?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Modelo> CreateAsync(Modelo entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Modelo entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
