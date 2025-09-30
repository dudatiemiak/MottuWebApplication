using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly AppDbContext _ctx;
        public ModeloRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Modelo>> GetAllAsync() => await _ctx.Modelos.AsNoTracking().ToListAsync();
        public async Task<Modelo?> GetByIdAsync(int id) => await _ctx.Modelos.FindAsync(id);
        public async Task<Modelo> CreateAsync(Modelo entity) { await _ctx.Modelos.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Modelo entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Modelos.FindAsync(id); if (e==null) return false; _ctx.Modelos.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
