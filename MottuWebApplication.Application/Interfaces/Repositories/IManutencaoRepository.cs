using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IManutencaoRepository
    {
        Task<IReadOnlyList<Manutencao>> GetAllAsync();
        Task<Manutencao?> GetByIdAsync(int id);
        Task<Manutencao> CreateAsync(Manutencao entity);
        Task UpdateAsync(Manutencao entity);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Manutencao>> GetByMotoAsync(int idMoto);
        Task<IReadOnlyList<Manutencao>> GetByDataEntradaAsync(DateTime minDate);
    }
}
