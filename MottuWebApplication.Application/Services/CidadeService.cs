using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _repo;
        public CidadeService(ICidadeRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Cidade>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Cidade?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Cidade> CreateAsync(Cidade entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Cidade entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
