using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFilialService
    {
        Task<IEnumerable<Filial>> GetAllFiliaisAsync();
        Task<Filial?> GetFilialByIdAsync(int id);
        Task CreateFilialAsync(Filial newFilial);
        Task<bool> UpdateFilialAsync(int id, Filial updatedFilial);
        Task<bool> DeleteFilialAsync(int id);

        Task<IEnumerable<Filial>> GetByNomeAsync(string nome);
    }
}
