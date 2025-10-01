using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class BairroService : IBairroService
    {
        private readonly IBairroRepository _repo;
        public BairroService(IBairroRepository repo){
            _repo = repo;
        }
        public Task<IEnumerable<Bairro>> GetAllBairrosAsync() => _repo.GetAllAsync();
        public Task<Bairro?> GetBairroByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateBairroAsync(Bairro newBairro) => _repo.CreateAsync(newBairro);
        public Task<bool> UpdateBairroAsync(int id, Bairro updatedBairro) => _repo.UpdateAsync(id, updatedBairro);
        public Task<bool> DeleteBairroAsync(int id) => _repo.DeleteAsync(id);
    }
}
