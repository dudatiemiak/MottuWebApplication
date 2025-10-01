using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _repo;
        public PaisService(IPaisRepository repo){
            _repo = repo;
        }

        public Task<IEnumerable<Pais>> GetAllPaisesAsync() => _repo.GetAllAsync();
        public Task<Pais?> GetPaisByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreatePaisAsync(Pais newPais) => _repo.CreateAsync(newPais);
        public Task<bool> UpdatePaisAsync(int id, Pais updatedPais) => _repo.UpdateAsync(id, updatedPais);
        public Task<bool> DeletePaisAsync(int id) => _repo.DeleteAsync(id);
    }
}
