using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _ctx;
        public ClienteRepository(AppDbContext ctx) {
            _ctx = ctx; 
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync() => 
            await _ctx.Clientes.AsNoTracking().ToListAsync();
        public async Task<Cliente?> GetByIdAsync(int id) => 
            await _ctx.Clientes.FindAsync(id);
        public async Task CreateAsync(Cliente cliente)
        {
            await _ctx.Clientes.AddAsync(cliente);
            await _ctx.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, Cliente clienteIn)
        {
            if (id != clienteIn.IdCliente) return false;
            _ctx.Entry(clienteIn).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _ctx.Clientes.FindAsync(id);
            if (result == null) return false;
            _ctx.Clientes.Remove(result);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Cliente>> GetByNomeAsync(string nome)
            => await _ctx.Clientes.AsNoTracking().Where(c => c.NmCliente.Contains(nome)).ToListAsync();
        public async Task<IEnumerable<Cliente>> GetByCpfAsync(string cpf)
            => await _ctx.Clientes.AsNoTracking().Where(c => c.NrCpf == cpf).ToListAsync();
        public async Task<IEnumerable<Cliente>> GetByEmailAsync(string email)
            => await _ctx.Clientes.AsNoTracking().Where(c => c.NmEmail.Contains(email)).ToListAsync();
    }
}
