using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly AppDbContext _ctx;
        public EstadoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Estado>> GetAllAsync() => await _ctx.Estados.AsNoTracking().ToListAsync();
        public async Task<Estado?> GetByIdAsync(int id) => await _ctx.Estados.FindAsync(id);
        public async Task<Estado> CreateAsync(Estado entity) { await _ctx.Estados.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Estado entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Estados.FindAsync(id); if (e==null) return false; _ctx.Estados.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
