using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> GetAllAsync();
        Task<Funcionario?> GetByIdAsync(int id);
        Task CreateAsync(Funcionario funcionario);
        Task<bool> UpdateAsync(int id, Funcionario funcionarioIn);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Funcionario>> GetByNomeAsync(string nome);
        Task<IEnumerable<Funcionario>> GetByCargoAsync(string cargo);
        Task<IEnumerable<Funcionario>> GetByEmailAsync(string email);
    }
}
