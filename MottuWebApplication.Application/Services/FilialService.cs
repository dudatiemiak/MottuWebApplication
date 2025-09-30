using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class FilialService : IFilialService
    {
        private readonly IFilialRepository _repo;
        public FilialService(IFilialRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Filial>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Filial?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Filial> CreateAsync(Filial entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Filial entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<IReadOnlyList<Filial>> GetByNomeAsync(string nome) => _repo.GetByNomeAsync(nome);
    }
}
