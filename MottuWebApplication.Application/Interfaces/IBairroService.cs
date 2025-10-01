using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IBairroService
    {
        Task<IEnumerable<Bairro>> GetAllBairrosAsync();
        Task<Bairro?> GetBairroByIdAsync(int id);
        Task CreateBairroAsync(Bairro newBairro);
        Task<bool> UpdateBairroAsync(int id, Bairro updatedBairro);
        Task<bool> DeleteBairroAsync(int id);
    }
}
