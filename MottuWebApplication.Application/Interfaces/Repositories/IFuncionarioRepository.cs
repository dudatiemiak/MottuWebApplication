using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IReadOnlyList<Funcionario>> GetAllAsync();
        Task<Funcionario?> GetByIdAsync(int id);
        Task<Funcionario> CreateAsync(Funcionario entity);
        Task UpdateAsync(Funcionario entity);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Funcionario>> GetByNomeAsync(string nome);
        Task<IReadOnlyList<Funcionario>> GetByCargoAsync(string cargo);
        Task<IReadOnlyList<Funcionario>> GetByEmailAsync(string email);
    }
}
