using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class FilialDepartamentoRepository : IFilialDepartamentoRepository
    {
        private readonly AppDbContext _ctx;
        public FilialDepartamentoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<FilialDepartamento>> GetAllAsync() => await _ctx.FilialDepartamentos.AsNoTracking().ToListAsync();
        public async Task<FilialDepartamento?> GetByIdAsync(int id) => await _ctx.FilialDepartamentos.FindAsync(id);
        public async Task<FilialDepartamento> CreateAsync(FilialDepartamento entity) { await _ctx.FilialDepartamentos.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(FilialDepartamento entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.FilialDepartamentos.FindAsync(id); if (e==null) return false; _ctx.FilialDepartamentos.Remove(e); await _ctx.SaveChangesAsync(); return true; }
    }
}
