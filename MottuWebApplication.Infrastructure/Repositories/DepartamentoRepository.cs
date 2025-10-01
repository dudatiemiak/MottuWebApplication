using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Infrastructure.Data;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Infrastructure.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly AppDbContext _ctx;
        public DepartamentoRepository(AppDbContext ctx){
            _ctx = ctx;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync() => 
            await _ctx.Departamentos.AsNoTracking().ToListAsync();
        public async Task<Departamento?> GetByIdAsync(int id) => 
            await _ctx.Departamentos.FindAsync(id);
        public async Task CreateAsync(Departamento departamento) { 
            await _ctx.Departamentos.AddAsync(departamento); 
            await _ctx.SaveChangesAsync(); 
        }
        public async Task<bool> UpdateAsync(int id, Departamento departamentoIn) {
            if (id != departamentoIn.IdDepartamento) return false;
            _ctx.Entry(departamentoIn).State = EntityState.Modified; 
            await _ctx.SaveChangesAsync(); return true; 
        }
        public async Task<bool> DeleteAsync(int id) { 
            var result = await _ctx.Departamentos.FindAsync(id); 
            if (result == null) return false; 
            _ctx.Departamentos.Remove(result); 
            await _ctx.SaveChangesAsync(); 
            return true; 
        }
    }
}
