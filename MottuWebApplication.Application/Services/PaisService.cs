using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _repo;
        public PaisService(IPaisRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Pais>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Pais?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Pais> CreateAsync(Pais entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Pais entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
