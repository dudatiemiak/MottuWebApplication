using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class FilialDepartamentoRepository : IFilialDepartamentoRepository
    {
        private readonly AppDbContext _ctx;
        public FilialDepartamentoRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<FilialDepartamento>> GetAllAsync() => 
            await _ctx.FilialDepartamentos.AsNoTracking().ToListAsync();
        public async Task<FilialDepartamento?> GetByIdAsync(int id) => 
            await _ctx.FilialDepartamentos.FindAsync(id);
        public async Task CreateAsync(FilialDepartamento filialDepartamento) { 
            await _ctx.FilialDepartamentos.AddAsync(filialDepartamento); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, FilialDepartamento filialDepartamentoIn) {
            if (id != filialDepartamentoIn.IdFilialDepartamento) return false;
            _ctx.Entry(filialDepartamentoIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.FilialDepartamentos.FindAsync(id); 
            if (result == null) return false; 
            _ctx.FilialDepartamentos.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
