using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
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

        public Task<IReadOnlyList<Cliente>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Cliente?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            // Basic validations migrated from controller
            if (string.IsNullOrEmpty(cliente.NmCliente)) throw new ArgumentException("O nome do cliente é obrigatório.");
            if (cliente.NmCliente.Length > 100) throw new ArgumentException("O nome do cliente excede 100 caracteres.");
            if (string.IsNullOrEmpty(cliente.NrCpf) || cliente.NrCpf.Length != 14) throw new ArgumentException("O CPF deve ter 14 caracteres (com pontuação).");
            if (string.IsNullOrEmpty(cliente.NmEmail) || !cliente.NmEmail.Contains("@")) throw new ArgumentException("E-mail inválido.");

            return await _repo.CreateAsync(cliente);
        }

        public async Task UpdateAsync(Cliente cliente) => await _repo.UpdateAsync(cliente);

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public Task<IReadOnlyList<Cliente>> GetByNomeAsync(string nome)
            => _repo.GetByNomeAsync(nome);

        public Task<IReadOnlyList<Cliente>> GetByCpfAsync(string cpf)
            => _repo.GetByCpfAsync(cpf);

        public Task<IReadOnlyList<Cliente>> GetByEmailAsync(string email)
            => _repo.GetByEmailAsync(email);
    }
}
