using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class FilialRepository : IFilialRepository
    {
        private readonly AppDbContext _ctx;
        public FilialRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Filial>> GetAllAsync() => await _ctx.Filiais.AsNoTracking().ToListAsync();
        public async Task<Filial?> GetByIdAsync(int id) => await _ctx.Filiais.FindAsync(id);
        public async Task<Filial> CreateAsync(Filial entity) { await _ctx.Filiais.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Filial entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Filiais.FindAsync(id); if (e==null) return false; _ctx.Filiais.Remove(e); await _ctx.SaveChangesAsync(); return true; }

        public async Task<IReadOnlyList<Filial>> GetByNomeAsync(string nome)
            => await _ctx.Filiais.AsNoTracking().Where(f => f.NmFilial.Contains(nome)).ToListAsync();
    }
}
