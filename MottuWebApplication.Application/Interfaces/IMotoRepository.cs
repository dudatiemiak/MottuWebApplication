using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IMotoRepository
    {
        Task<IEnumerable<Moto>> GetAllAsync();
        Task<Moto?> GetByIdAsync(int id);
        Task CreateAsync(Moto moto);
        Task<bool> UpdateAsync(int id, Moto motoIn);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Moto>> GetByPlacaAsync(string placa);
        Task<IEnumerable<Moto>> GetByStatusAsync(string status);
        Task<IEnumerable<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento);
    }
}
