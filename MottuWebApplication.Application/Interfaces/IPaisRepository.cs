using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> GetAllAsync();
        Task<Pais?> GetByIdAsync(int id);
        Task CreateAsync(Pais pais);
        Task<bool> UpdateAsync(int id, Pais paisIn);
        Task<bool> DeleteAsync(int id);
    }
}
