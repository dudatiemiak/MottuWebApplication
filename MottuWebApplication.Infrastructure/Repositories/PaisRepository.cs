using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly AppDbContext _ctx;
        public PaisRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Pais>> GetAllAsync() => await _ctx.Paises.AsNoTracking().ToListAsync();
        public async Task<Pais?> GetByIdAsync(int id) => await _ctx.Paises.FindAsync(id);
        public async Task<Pais> CreateAsync(Pais entity) { await _ctx.Paises.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Pais entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Paises.FindAsync(id); if (e==null) return false; _ctx.Paises.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
