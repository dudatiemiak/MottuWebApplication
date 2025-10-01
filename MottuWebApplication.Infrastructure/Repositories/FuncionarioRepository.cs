using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _ctx;
        public FuncionarioRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Funcionario>> GetAllAsync() => 
            await _ctx.Funcionarios.AsNoTracking().ToListAsync();
        public async Task<Funcionario?> GetByIdAsync(int id) => 
            await _ctx.Funcionarios.FindAsync(id);
        public async Task CreateAsync(Funcionario funcionario) { 
            await _ctx.Funcionarios.AddAsync(funcionario); 
            await _ctx.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, Funcionario funcionarioIn) { 
            if (id != funcionarioIn.IdFuncionario) return false; 
            _ctx.Entry(funcionarioIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Funcionarios.FindAsync(id);
            if (result == null) return false; 
            _ctx.Funcionarios.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }

        public async Task<IEnumerable<Funcionario>> GetByNomeAsync(string nome)
            => await _ctx.Funcionarios.AsNoTracking().Where(f => f.NmFuncionario.Contains(nome)).ToListAsync();
        public async Task<IEnumerable<Funcionario>> GetByCargoAsync(string cargo)
            => await _ctx.Funcionarios.AsNoTracking().Where(f => f.NmCargo == cargo).ToListAsync();
        public async Task<IEnumerable<Funcionario>> GetByEmailAsync(string email)
            => await _ctx.Funcionarios.AsNoTracking().Where(f => f.NmEmailCorporativo.Contains(email)).ToListAsync();
    }
}
