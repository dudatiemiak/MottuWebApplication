using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly AppDbContext _ctx;
        public LogradouroRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Logradouro>> GetAllAsync() => await _ctx.Logradouros.AsNoTracking().ToListAsync();
        public async Task<Logradouro?> GetByIdAsync(int id) => await _ctx.Logradouros.FindAsync(id);
        public async Task<Logradouro> CreateAsync(Logradouro entity) { await _ctx.Logradouros.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Logradouro entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Logradouros.FindAsync(id); if (e==null) return false; _ctx.Logradouros.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
