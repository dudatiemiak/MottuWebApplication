using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IBairroService
    {
        Task<IReadOnlyList<Bairro>> GetAllAsync();
        Task<Bairro?> GetByIdAsync(int id);
        Task<Bairro> CreateAsync(Bairro entity);
        Task UpdateAsync(Bairro entity);
        Task<bool> DeleteAsync(int id);
    }
}
