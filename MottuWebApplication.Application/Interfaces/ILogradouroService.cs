using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface ILogradouroService
    {
        Task<IEnumerable<Logradouro>> GetAllLogradourosAsync();
        Task<Logradouro?> GetLogradouroByIdAsync(int id);
        Task CreateLogradouroAsync(Logradouro newLogradouro);
        Task<bool> UpdateLogradouroAsync(int id, Logradouro updatedLogradouro);
        Task<bool> DeleteLogradouroAsync(int id);
    }
}
