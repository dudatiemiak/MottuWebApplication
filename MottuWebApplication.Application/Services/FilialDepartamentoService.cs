using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class FilialDepartamentoService : IFilialDepartamentoService
    {
        private readonly IFilialDepartamentoRepository _repo;
        public FilialDepartamentoService(IFilialDepartamentoRepository repo) => _repo = repo;
        public Task<IReadOnlyList<FilialDepartamento>> GetAllAsync() => _repo.GetAllAsync();
        public Task<FilialDepartamento?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<FilialDepartamento> CreateAsync(FilialDepartamento entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(FilialDepartamento entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
