using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFilialService
    {
        Task<IReadOnlyList<Filial>> GetAllAsync();
        Task<Filial?> GetByIdAsync(int id);
        Task<Filial> CreateAsync(Filial entity);
        Task UpdateAsync(Filial entity);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Filial>> GetByNomeAsync(string nome);
    }
}
