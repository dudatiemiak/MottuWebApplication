using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IReadOnlyList<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Cliente>> GetByNomeAsync(string nome);
        Task<IReadOnlyList<Cliente>> GetByCpfAsync(string cpf);
        Task<IReadOnlyList<Cliente>> GetByEmailAsync(string email);
    }
}
