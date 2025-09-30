using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly AppDbContext _ctx;
        public ManutencaoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Manutencao>> GetAllAsync() => await _ctx.Manutencoes.AsNoTracking().ToListAsync();
        public async Task<Manutencao?> GetByIdAsync(int id) => await _ctx.Manutencoes.FindAsync(id);
        public async Task<Manutencao> CreateAsync(Manutencao entity) { await _ctx.Manutencoes.AddAsync(entity); await _ctx.SaveChangesAsync(); return entity; }
        public async Task UpdateAsync(Manutencao entity) { _ctx.Entry(entity).State = EntityState.Modified; await _ctx.SaveChangesAsync(); }
        public async Task<bool> DeleteAsync(int id) { var e = await _ctx.Manutencoes.FindAsync(id); if (e==null) return false; _ctx.Manutencoes.Remove(e); await _ctx.SaveChangesAsync(); return true; }

        public async Task<IReadOnlyList<Manutencao>> GetByMotoAsync(int idMoto)
            => await _ctx.Manutencoes.AsNoTracking().Where(m => m.IdMoto == idMoto).ToListAsync();
        public async Task<IReadOnlyList<Manutencao>> GetByDataEntradaAsync(DateTime minDate)
            => await _ctx.Manutencoes.AsNoTracking().Where(m => m.DtEntrada.Date >= minDate.Date).ToListAsync();
    }
}
