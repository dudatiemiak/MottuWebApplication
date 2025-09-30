using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly AppDbContext _ctx;
        public MotoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<IReadOnlyList<Moto>> GetAllAsync() => await _ctx.Motos.AsNoTracking().ToListAsync();
        public async Task<Moto?> GetByIdAsync(int id) => await _ctx.Motos.FindAsync(id);
        public async Task<Moto> CreateAsync(Moto entity)
        {
            await _ctx.Motos.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(Moto entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _ctx.Motos.FindAsync(id);
            if (entity == null) return false;
            _ctx.Motos.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<Moto>> GetByPlacaAsync(string placa)
            => await _ctx.Motos.AsNoTracking().Where(m => m.NmPlaca.ToLower() == placa.ToLower()).ToListAsync();
        public async Task<IReadOnlyList<Moto>> GetByStatusAsync(string status)
            => await _ctx.Motos.AsNoTracking().Where(m => m.StMoto.ToLower() == status.ToLower()).ToListAsync();
        public async Task<IReadOnlyList<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento)
            => await _ctx.Motos.AsNoTracking().Where(m => m.IdFilialDepartamento == idFilialDepartamento).ToListAsync();
    }
}
