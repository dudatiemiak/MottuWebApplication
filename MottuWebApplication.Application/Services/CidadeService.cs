using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _repo;
        public CidadeService(ICidadeRepository repo){
            _repo = repo;
        }
        public Task<IEnumerable<Cidade>> GetAllCidadesAsync() => _repo.GetAllAsync();
        public Task<Cidade?> GetCidadeByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateCidadeAsync(Cidade newCidade) => _repo.CreateAsync(newCidade);
        public Task<bool> UpdateCidadeAsync(int id, Cidade updatedCidade) => _repo.UpdateAsync(id, updatedCidade);
        public Task<bool> DeleteCidadeAsync(int id) => _repo.DeleteAsync(id);
    }
}
