using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly AppDbContext _ctx;
        public PaisRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Pais>> GetAllAsync() => 
            await _ctx.Paises.AsNoTracking().ToListAsync();
        public async Task<Pais?> GetByIdAsync(int id) => 
            await _ctx.Paises.FindAsync(id);
        public async Task CreateAsync(Pais pais) { 
            await _ctx.Paises.AddAsync(pais); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Pais paisIn) { 
            if (id != paisIn.IdPais) return false; 
            _ctx.Entry(paisIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Paises.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Paises.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
