using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly AppDbContext _ctx;
        public CidadeRepository(AppDbContext ctx){ 
            _ctx = ctx; 
        }

        public async Task<IEnumerable<Cidade>> GetAllAsync() => 
            await _ctx.Cidades.AsNoTracking().ToListAsync();
        public async Task<Cidade?> GetByIdAsync(int id) => 
            await _ctx.Cidades.FindAsync(id);
        public async Task CreateAsync(Cidade cidade) { 
            await _ctx.Cidades.AddAsync(cidade); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Cidade cidadeIn) {
            if (id != cidadeIn.IdCidade) return false; 
            _ctx.Entry(cidadeIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); return true; 
        }
        public async Task<bool> DeleteAsync(int id) {
            var result = await _ctx.Cidades.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Cidades.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
