using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _repo;
        public ModeloService(IModeloRepository repo){
            _repo = repo;
        }

        public Task<IEnumerable<Modelo>> GetAllModelosAsync() => _repo.GetAllAsync();
        public Task<Modelo?> GetModeloByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateModeloAsync(Modelo newModelo) => _repo.CreateAsync(newModelo);
        public Task<bool> UpdateModeloAsync(int id, Modelo updatedModelo) => _repo.UpdateAsync(id, updatedModelo);
        public Task<bool> DeleteModeloAsync(int id) => _repo.DeleteAsync(id);
    }
}
