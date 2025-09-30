using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repo;
        public DepartamentoService(IDepartamentoRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Departamento>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Departamento?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Departamento> CreateAsync(Departamento entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Departamento entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
