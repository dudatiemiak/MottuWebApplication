using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IPaisService
    {
        Task<IEnumerable<Pais>> GetAllPaisesAsync();
        Task<Pais?> GetPaisByIdAsync(int id);
        Task CreatePaisAsync(Pais newPais);
        Task<bool> UpdatePaisAsync(int id, Pais updatedPais);
        Task<bool> DeletePaisAsync(int id);
    }
}
