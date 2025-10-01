using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly AppDbContext _ctx;
        public ModeloRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Modelo>> GetAllAsync() => 
            await _ctx.Modelos.AsNoTracking().ToListAsync();
        public async Task<Modelo?> GetByIdAsync(int id) => 
            await _ctx.Modelos.FindAsync(id);
        public async Task CreateAsync(Modelo modelo) { 
            await _ctx.Modelos.AddAsync(modelo); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Modelo modeloIn) { 
            if (id != modeloIn.IdModelo) return false; 
            _ctx.Entry(modeloIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Modelos.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Modelos.Remove(result); 
            await _ctx.SaveChangesAsync(); return true; 
        }
    }
}
