using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _repo;
        public LogradouroService(ILogradouroRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Logradouro>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Logradouro?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Logradouro> CreateAsync(Logradouro entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Logradouro entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
