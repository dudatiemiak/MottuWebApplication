using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IFilialRepository
    {
        Task<IEnumerable<Filial>> GetAllAsync();
        Task<Filial?> GetByIdAsync(int id);
        Task CreateAsync(Filial filial);
        Task<bool> UpdateAsync(int id, Filial filialIn);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Filial>> GetByNomeAsync(string nome);
    }
}
