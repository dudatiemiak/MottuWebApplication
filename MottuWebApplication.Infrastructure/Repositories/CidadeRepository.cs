using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly AppDbContext _ctx;
        public CidadeRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Cidade>> GetAllAsync() => await _ctx.Cidades.AsNoTracking().ToListAsync();
        public async Task<Cidade?> GetByIdAsync(int id) => await _ctx.Cidades.FindAsync(id);
        public async Task<Cidade> CreateAsync(Cidade entity) { await _ctx.Cidades.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Cidade entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Cidades.FindAsync(id); if (e==null) return false; _ctx.Cidades.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
