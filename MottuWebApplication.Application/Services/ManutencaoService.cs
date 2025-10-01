using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class ManutencaoService : IManutencaoService
    {
        private readonly IManutencaoRepository _repo;
        public ManutencaoService(IManutencaoRepository repo){
            _repo = repo;
        }

        public Task<IEnumerable<Manutencao>> GetAllManutencoesAsync() => _repo.GetAllAsync();
        public Task<Manutencao?> GetManutencaoByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateManutencaoAsync(Manutencao newManutencao) => _repo.CreateAsync(newManutencao);
        public Task<bool> UpdateManutencaoAsync(int id, Manutencao updatedManutencao) => _repo.UpdateAsync(id, updatedManutencao);
        public Task<bool> DeleteManutencaoAsync(int id) => _repo.DeleteAsync(id);
        public Task<IEnumerable<Manutencao>> GetByMotoAsync(int idMoto) => _repo.GetByMotoAsync(idMoto);
        public Task<IEnumerable<Manutencao>> GetByDataEntradaAsync(DateTime minDate) => _repo.GetByDataEntradaAsync(minDate);
    }
}
