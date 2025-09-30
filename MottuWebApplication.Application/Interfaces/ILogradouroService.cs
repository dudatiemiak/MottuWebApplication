using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface ILogradouroService
    {
        Task<IReadOnlyList<Logradouro>> GetAllAsync();
        Task<Logradouro?> GetByIdAsync(int id);
        Task<Logradouro> CreateAsync(Logradouro entity);
        Task UpdateAsync(Logradouro entity);
        Task<bool> DeleteAsync(int id);
    }
}
