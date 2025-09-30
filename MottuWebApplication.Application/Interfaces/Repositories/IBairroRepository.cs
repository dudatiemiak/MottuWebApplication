using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IBairroRepository
    {
        Task<IReadOnlyList<Bairro>> GetAllAsync();
        Task<Bairro?> GetByIdAsync(int id);
        Task<Bairro> CreateAsync(Bairro entity);
        Task UpdateAsync(Bairro entity);
        Task<bool> DeleteAsync(int id);
    }
}
