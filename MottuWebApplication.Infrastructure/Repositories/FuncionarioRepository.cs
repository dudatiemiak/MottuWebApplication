using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _ctx;
        public FuncionarioRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Funcionario>> GetAllAsync() => await _ctx.Funcionarios.AsNoTracking().ToListAsync();
        public async Task<Funcionario?> GetByIdAsync(int id) => await _ctx.Funcionarios.FindAsync(id);
        public async Task<Funcionario> CreateAsync(Funcionario entity) { await _ctx.Funcionarios.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Funcionario entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Funcionarios.FindAsync(id); if (e==null) return false; _ctx.Funcionarios.Remove(e); await _ctx.SaveChangesAsync(); return true; }

        public async Task<IReadOnlyList<Funcionario>> GetByNomeAsync(string nome)
            => await _ctx.Funcionarios.AsNoTracking().Where(f => f.NmFuncionario.Contains(nome)).ToListAsync();
        public async Task<IReadOnlyList<Funcionario>> GetByCargoAsync(string cargo)
            => await _ctx.Funcionarios.AsNoTracking().Where(f => f.NmCargo == cargo).ToListAsync();
        public async Task<IReadOnlyList<Funcionario>> GetByEmailAsync(string email)
            => await _ctx.Funcionarios.AsNoTracking().Where(f => f.NmEmailCorporativo.Contains(email)).ToListAsync();
    }
}
