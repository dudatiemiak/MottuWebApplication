using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface ICidadeService
    {
        Task<IEnumerable<Cidade>> GetAllCidadesAsync();
        Task<Cidade?> GetCidadeByIdAsync(int id);
        Task CreateCidadeAsync(Cidade newCidade);
        Task<bool> UpdateCidadeAsync(int id, Cidade updatedCidade);
        Task<bool> DeleteCidadeAsync(int id);
    }
}
