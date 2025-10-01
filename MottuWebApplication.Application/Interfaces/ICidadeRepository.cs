using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface ICidadeRepository
    {
        Task<IEnumerable<Cidade>> GetAllAsync();
        Task<Cidade?> GetByIdAsync(int id);
        Task CreateAsync(Cidade cidade);
        Task<bool> UpdateAsync(int id, Cidade cidadeIn);
        Task<bool> DeleteAsync(int id);
    }
}
