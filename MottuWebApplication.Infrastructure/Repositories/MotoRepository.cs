using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly AppDbContext _ctx;
        public MotoRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Moto>> GetAllAsync() => 
            await _ctx.Motos.AsNoTracking().ToListAsync();
        public async Task<Moto?> GetByIdAsync(int id) => 
            await _ctx.Motos.FindAsync(id);
        public async Task CreateAsync(Moto moto)
        {
            await _ctx.Motos.AddAsync(moto);
            await _ctx.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(int id, Moto motoIn)
        {
            if (id != motoIn.IdMoto) return false;
            _ctx.Entry(motoIn).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _ctx.Motos.FindAsync(id);
            if (result == null) return false;
            _ctx.Motos.Remove(result);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Moto>> GetByPlacaAsync(string placa)
            => await _ctx.Motos.AsNoTracking().Where(m => m.NmPlaca.ToLower() == placa.ToLower()).ToListAsync();
        public async Task<IEnumerable<Moto>> GetByStatusAsync(string status)
            => await _ctx.Motos.AsNoTracking().Where(m => m.StMoto.ToLower() == status.ToLower()).ToListAsync();
        public async Task<IEnumerable<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento)
            => await _ctx.Motos.AsNoTracking().Where(m => m.IdFilialDepartamento == idFilialDepartamento).ToListAsync();
    }
}
