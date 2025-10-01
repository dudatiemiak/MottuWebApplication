using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface ILogradouroRepository
    {
        Task<IEnumerable<Logradouro>> GetAllAsync();
        Task<Logradouro?> GetByIdAsync(int id);
        Task CreateAsync(Logradouro logradouro);
        Task<bool> UpdateAsync(int id, Logradouro logradouroIn);
        Task<bool> DeleteAsync(int id);
    }
}
