using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task CreateAsync(Cliente cliente);
        Task<bool> UpdateAsync(int id, Cliente clienteIn);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Cliente>> GetByNomeAsync(string nome);
        Task<IEnumerable<Cliente>> GetByCpfAsync(string cpf);
        Task<IEnumerable<Cliente>> GetByEmailAsync(string email);
    }
}
