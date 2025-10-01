using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IBairroRepository
    {
        Task<IEnumerable<Bairro>> GetAllAsync();
        Task<Bairro?> GetByIdAsync(int id);
        Task CreateAsync(Bairro bairro);
        Task<bool> UpdateAsync(int id, Bairro bairroIn);
        Task<bool> DeleteAsync(int id);
    }
}
