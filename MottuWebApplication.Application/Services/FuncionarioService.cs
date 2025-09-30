using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repo;
        public FuncionarioService(IFuncionarioRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Funcionario>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Funcionario?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Funcionario> CreateAsync(Funcionario entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Funcionario entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<IReadOnlyList<Funcionario>> GetByNomeAsync(string nome) => _repo.GetByNomeAsync(nome);
        public Task<IReadOnlyList<Funcionario>> GetByCargoAsync(string cargo) => _repo.GetByCargoAsync(cargo);
        public Task<IReadOnlyList<Funcionario>> GetByEmailAsync(string email) => _repo.GetByEmailAsync(email);
    }
}
