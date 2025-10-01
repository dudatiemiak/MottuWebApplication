using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly AppDbContext _ctx;
        public EstadoRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Estado>> GetAllAsync() => 
            await _ctx.Estados.AsNoTracking().ToListAsync();
        public async Task<Estado?> GetByIdAsync(int id) => 
            await _ctx.Estados.FindAsync(id);
        public async Task CreateAsync(Estado estado) {
            await _ctx.Estados.AddAsync(estado); 
            await _ctx.SaveChangesAsync(); }
        public async Task<bool> UpdateAsync(int id, Estado estadoIn) {
            if (id != estadoIn.IdEstado) return false; 
            _ctx.Entry(estadoIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Estados.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Estados.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
