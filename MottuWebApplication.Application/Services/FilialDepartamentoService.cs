using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class FilialDepartamentoService : IFilialDepartamentoService
    {
        private readonly IFilialDepartamentoRepository _repo;
        public FilialDepartamentoService(IFilialDepartamentoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<FilialDepartamento>> GetAllFilialDepartamentosAsync() => _repo.GetAllAsync();
        public Task<FilialDepartamento?> GetFilialDepartamentoByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateFilialDepartamentoAsync(FilialDepartamento newFilialDepartamento) => _repo.CreateAsync(newFilialDepartamento);
        public Task<bool> UpdateFilialDepartamentoAsync(int id, FilialDepartamento updatedFilialDepartamento) => _repo.UpdateAsync(id, updatedFilialDepartamento);
        public Task<bool> DeleteFilialDepartamentoAsync(int id) => _repo.DeleteAsync(id);
    }
}
