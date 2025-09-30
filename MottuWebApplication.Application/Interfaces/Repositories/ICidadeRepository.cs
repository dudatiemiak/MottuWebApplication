using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface ICidadeRepository
    {
        Task<IReadOnlyList<Cidade>> GetAllAsync();
        Task<Cidade?> GetByIdAsync(int id);
        Task<Cidade> CreateAsync(Cidade entity);
        Task UpdateAsync(Cidade entity);
        Task<bool> DeleteAsync(int id);
    }
}
