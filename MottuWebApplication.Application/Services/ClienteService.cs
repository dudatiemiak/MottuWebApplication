using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

    public Task<IEnumerable<Cliente>> GetAllClientesAsync() => _repo.GetAllAsync();

    public Task<Cliente?> GetClienteByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task CreateClienteAsync(Cliente newCliente)
    {
         // Validações básicas
         if (string.IsNullOrEmpty(newCliente.NmCliente)) throw new ArgumentException("O nome do cliente é obrigatório.");
         if (newCliente.NmCliente.Length > 100) throw new ArgumentException("O nome do cliente excede 100 caracteres.");
         if (string.IsNullOrEmpty(newCliente.NrCpf) || newCliente.NrCpf.Length != 14) throw new ArgumentException("O CPF deve ter 14 caracteres (com pontuação).");
         if (string.IsNullOrEmpty(newCliente.NmEmail) || !newCliente.NmEmail.Contains("@")) throw new ArgumentException("E-mail inválido.");

         await _repo.CreateAsync(newCliente);
    }

    public Task<bool> UpdateClienteAsync(int id, Cliente updatedCliente) => _repo.UpdateAsync(id, updatedCliente);

    public async Task<bool> DeleteClienteAsync(int id)
    {
         return await _repo.DeleteAsync(id);
    }

    public Task<IEnumerable<Cliente>> GetByNomeAsync(string nome)
        => _repo.GetByNomeAsync(nome);

    public Task<IEnumerable<Cliente>> GetByCpfAsync(string cpf)
        => _repo.GetByCpfAsync(cpf);

    public Task<IEnumerable<Cliente>> GetByEmailAsync(string email)
        => _repo.GetByEmailAsync(email);
    }
}
