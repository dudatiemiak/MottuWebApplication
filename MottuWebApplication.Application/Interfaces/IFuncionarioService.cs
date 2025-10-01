using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync();
        Task<Funcionario?> GetFuncionarioByIdAsync(int id);
        Task CreateFuncionarioAsync(Funcionario newFuncionario);
        Task<bool> UpdateFuncionarioAsync(int id, Funcionario updatedFuncionario);
        Task<bool> DeleteFuncionarioAsync(int id);

        Task<IEnumerable<Funcionario>> GetByNomeAsync(string nome);
        Task<IEnumerable<Funcionario>> GetByCargoAsync(string cargo);
        Task<IEnumerable<Funcionario>> GetByEmailAsync(string email);
    }
}
