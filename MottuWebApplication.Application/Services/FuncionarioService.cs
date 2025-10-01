using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repo;
        public FuncionarioService(IFuncionarioRepository repo){
            _repo = repo;
        }

        public Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync() => _repo.GetAllAsync();
        public Task<Funcionario?> GetFuncionarioByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateFuncionarioAsync(Funcionario newFuncionario) => _repo.CreateAsync(newFuncionario);
        public Task<bool> UpdateFuncionarioAsync(int id, Funcionario updatedFuncionario) => _repo.UpdateAsync(id, updatedFuncionario);
        public Task<bool> DeleteFuncionarioAsync(int id) => _repo.DeleteAsync(id);
        public Task<IEnumerable<Funcionario>> GetByNomeAsync(string nome) => _repo.GetByNomeAsync(nome);
        public Task<IEnumerable<Funcionario>> GetByCargoAsync(string cargo) => _repo.GetByCargoAsync(cargo);
        public Task<IEnumerable<Funcionario>> GetByEmailAsync(string email) => _repo.GetByEmailAsync(email);
    }
}
