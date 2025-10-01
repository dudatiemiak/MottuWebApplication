using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly AppDbContext _ctx;
        public ManutencaoRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Manutencao>> GetAllAsync() => 
            await _ctx.Manutencoes.AsNoTracking().ToListAsync();
        public async Task<Manutencao?> GetByIdAsync(int id) => 
            await _ctx.Manutencoes.FindAsync(id);
        public async Task CreateAsync(Manutencao manutencao) { 
            await _ctx.Manutencoes.AddAsync(manutencao); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Manutencao manutencaoIn) { 
            if (id != manutencaoIn.IdManutencao) return false; 
            _ctx.Entry(manutencaoIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync();
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Manutencoes.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Manutencoes.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }

        public async Task<IEnumerable<Manutencao>> GetByMotoAsync(int idMoto)
            => await _ctx.Manutencoes.AsNoTracking().Where(m => m.IdMoto == idMoto).ToListAsync();
        public async Task<IEnumerable<Manutencao>> GetByDataEntradaAsync(DateTime minDate)
            => await _ctx.Manutencoes.AsNoTracking().Where(m => m.DtEntrada.Date >= minDate.Date).ToListAsync();
    }
}
