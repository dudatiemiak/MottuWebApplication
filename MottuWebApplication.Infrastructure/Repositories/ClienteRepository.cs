using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _ctx;
        public ClienteRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Cliente>> GetAllAsync() => await _ctx.Clientes.AsNoTracking().ToListAsync();
        public async Task<Cliente?> GetByIdAsync(int id) => await _ctx.Clientes.FindAsync(id);
        public async Task<Cliente> CreateAsync(Cliente entity)
        {
            await _ctx.Clientes.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Cliente entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _ctx.Clientes.FindAsync(id);
            if (entity == null) return false;
            _ctx.Clientes.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<Cliente>> GetByNomeAsync(string nome)
            => await _ctx.Clientes.AsNoTracking().Where(c => c.NmCliente.Contains(nome)).ToListAsync();
        public async Task<IReadOnlyList<Cliente>> GetByCpfAsync(string cpf)
            => await _ctx.Clientes.AsNoTracking().Where(c => c.NrCpf == cpf).ToListAsync();
        public async Task<IReadOnlyList<Cliente>> GetByEmailAsync(string email)
            => await _ctx.Clientes.AsNoTracking().Where(c => c.NmEmail.Contains(email)).ToListAsync();
    }
}
