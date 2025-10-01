using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IManutencaoRepository
    {
        Task<IEnumerable<Manutencao>> GetAllAsync();
        Task<Manutencao?> GetByIdAsync(int id);
        Task CreateAsync(Manutencao manutencao);
        Task<bool> UpdateAsync(int id, Manutencao manutencaoIn);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Manutencao>> GetByMotoAsync(int idMoto);
        Task<IEnumerable<Manutencao>> GetByDataEntradaAsync(DateTime minDate);
    }
}
