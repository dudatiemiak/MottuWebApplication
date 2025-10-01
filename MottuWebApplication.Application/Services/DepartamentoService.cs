using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repo;
        public DepartamentoService(IDepartamentoRepository repo){
            _repo = repo;
        }
        public Task<IEnumerable<Departamento>> GetAllDepartamentosAsync() => _repo.GetAllAsync();
        public Task<Departamento?> GetDepartamentoByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateDepartamentoAsync(Departamento newDepartamento) => _repo.CreateAsync(newDepartamento);
        public Task<bool> UpdateDepartamentoAsync(int id, Departamento updatedDepartamento) => _repo.UpdateAsync(id, updatedDepartamento);
        public Task<bool> DeleteDepartamentoAsync(int id) => _repo.DeleteAsync(id);
    }
}
