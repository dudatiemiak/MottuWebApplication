using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class BairroRepository : IBairroRepository
    {
        private readonly AppDbContext _ctx;
        public BairroRepository(AppDbContext ctx){
            _ctx = ctx; 
        }

        public async Task<IEnumerable<Bairro>> GetAllAsync() => 
            await _ctx.Bairros.AsNoTracking().ToListAsync();
        public async Task<Bairro?> GetByIdAsync(int id) => await _ctx.Bairros.FindAsync(id);
        public async Task CreateAsync(Bairro bairro)
        {
            await _ctx.Bairros.AddAsync(bairro);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, Bairro bairroIn) {
            if (id != bairroIn.IdBairro) 
                return false;
            _ctx.Entry(bairroIn).State = EntityState.Modified;
            await _ctx.SaveChangesAsync(); return true; 
        }
        public async Task<bool> DeleteAsync(int id) {
            var result = await _ctx.Bairros.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Bairros.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
