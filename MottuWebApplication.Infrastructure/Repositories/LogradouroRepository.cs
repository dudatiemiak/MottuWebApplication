using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly AppDbContext _ctx;
        public LogradouroRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Logradouro>> GetAllAsync() => 
            await _ctx.Logradouros.AsNoTracking().ToListAsync();
        public async Task<Logradouro?> GetByIdAsync(int id) => 
            await _ctx.Logradouros.FindAsync(id);
        public async Task CreateAsync(Logradouro logradouro) { 
            await _ctx.Logradouros.AddAsync(logradouro); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Logradouro logradouroIn) { 
            if (id != logradouroIn.IdLogradouro) return false; 
            _ctx.Entry(logradouroIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Logradouros.FindAsync(id); 
            if (result == null) return false;
            _ctx.Logradouros.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
