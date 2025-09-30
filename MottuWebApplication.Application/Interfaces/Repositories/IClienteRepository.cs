using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IReadOnlyList<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente entity);
        Task UpdateAsync(Cliente entity);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Cliente>> GetByNomeAsync(string nome);
        Task<IReadOnlyList<Cliente>> GetByCpfAsync(string cpf);
        Task<IReadOnlyList<Cliente>> GetByEmailAsync(string email);
    }
}
