using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class FilialRepository : IFilialRepository
    {
        private readonly AppDbContext _ctx;
        public FilialRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Filial>> GetAllAsync() => 
            await _ctx.Filiais.AsNoTracking().ToListAsync();
        public async Task<Filial?> GetByIdAsync(int id) => 
            await _ctx.Filiais.FindAsync(id);
        public async Task CreateAsync(Filial filial) { 
            await _ctx.Filiais.AddAsync(filial); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Filial filialIn) { 
            if (id != filialIn.IdFilial) return false; 
            _ctx.Entry(filialIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Filiais.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Filiais.Remove(result);
            await _ctx.SaveChangesAsync(); 
            return true; 
        }

        public async Task<IEnumerable<Filial>> GetByNomeAsync(string nome)
            => await _ctx.Filiais.AsNoTracking().Where(f => f.NmFilial.Contains(nome)).ToListAsync();
    }
}
