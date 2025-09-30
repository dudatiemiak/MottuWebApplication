using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IMotoService
    {
        Task<IReadOnlyList<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(int id);
        Task<Moto> CreateAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task<bool> DeleteAsync(int id);

        Task<IReadOnlyList<Moto>> GetByPlacaAsync(string placa);
        Task<IReadOnlyList<Moto>> GetByStatusAsync(string status);
        Task<IReadOnlyList<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento);
    }
}
