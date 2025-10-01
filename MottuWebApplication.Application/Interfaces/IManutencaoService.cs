using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IManutencaoService
    {
        Task<IEnumerable<Manutencao>> GetAllManutencoesAsync();
        Task<Manutencao?> GetManutencaoByIdAsync(int id);
        Task CreateManutencaoAsync(Manutencao newManutencao);
        Task<bool> UpdateManutencaoAsync(int id, Manutencao updatedManutencao);
        Task<bool> DeleteManutencaoAsync(int id);

        Task<IEnumerable<Manutencao>> GetByMotoAsync(int idMoto);
        Task<IEnumerable<Manutencao>> GetByDataEntradaAsync(DateTime minDate);
    }
}
