using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class FilialService : IFilialService
    {
        private readonly IFilialRepository _repo;
        public FilialService(IFilialRepository repo){
            _repo = repo;
        }

        public Task<IEnumerable<Filial>> GetAllFiliaisAsync() => _repo.GetAllAsync();
        public Task<Filial?> GetFilialByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateFilialAsync(Filial newFilial) => _repo.CreateAsync(newFilial);
        public Task<bool> UpdateFilialAsync(int id, Filial updatedFilial) => _repo.UpdateAsync(id, updatedFilial);
        public Task<bool> DeleteFilialAsync(int id) => _repo.DeleteAsync(id);
        public Task<IEnumerable<Filial>> GetByNomeAsync(string nome) => _repo.GetByNomeAsync(nome);
    }
}
