using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces.Repositories
{
    public interface IMotoRepository
    {
        Task<IReadOnlyList<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(int id);
        Task<Moto> CreateAsync(Moto entity);
        Task UpdateAsync(Moto entity);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Moto>> GetByPlacaAsync(string placa);
        Task<IReadOnlyList<Moto>> GetByStatusAsync(string status);
        Task<IReadOnlyList<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento);
    }
}
