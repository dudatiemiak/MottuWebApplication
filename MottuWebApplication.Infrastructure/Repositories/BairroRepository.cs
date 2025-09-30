using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class BairroRepository : IBairroRepository
    {
        private readonly AppDbContext _ctx;
        public BairroRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Bairro>> GetAllAsync() => await _ctx.Bairros.AsNoTracking().ToListAsync();
        public async Task<Bairro?> GetByIdAsync(int id) => await _ctx.Bairros.FindAsync(id);
        public async Task<Bairro> CreateAsync(Bairro entity) { await _ctx.Bairros.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Bairro entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Bairros.FindAsync(id); if (e==null) return false; _ctx.Bairros.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
