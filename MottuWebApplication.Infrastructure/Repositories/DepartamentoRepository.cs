using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly AppDbContext _ctx;
        public DepartamentoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Departamento>> GetAllAsync() => await _ctx.Departamentos.AsNoTracking().ToListAsync();
        public async Task<Departamento?> GetByIdAsync(int id) => await _ctx.Departamentos.FindAsync(id);
        public async Task<Departamento> CreateAsync(Departamento entity) { await _ctx.Departamentos.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Departamento entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Departamentos.FindAsync(id); if (e==null) return false; _ctx.Departamentos.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
