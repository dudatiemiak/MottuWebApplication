using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class ManutencaoService : IManutencaoService
    {
        private readonly IManutencaoRepository _repo;
        public ManutencaoService(IManutencaoRepository repo) => _repo = repo;
        public Task<IReadOnlyList<Manutencao>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Manutencao?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Manutencao> CreateAsync(Manutencao entity) => _repo.CreateAsync(entity);
        public Task UpdateAsync(Manutencao entity) => _repo.UpdateAsync(entity);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<IReadOnlyList<Manutencao>> GetByMotoAsync(int idMoto) => _repo.GetByMotoAsync(idMoto);
        public Task<IReadOnlyList<Manutencao>> GetByDataEntradaAsync(DateTime minDate) => _repo.GetByDataEntradaAsync(minDate);
    }
}
