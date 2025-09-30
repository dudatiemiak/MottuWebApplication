using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class BairroService : IBairroService
    {
        private readonly IBairroRepository _repo;
        public BairroService(IBairroRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Bairro>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Bairro?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Bairro> CreateAsync(Bairro entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Bairro entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
