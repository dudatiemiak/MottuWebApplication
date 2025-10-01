using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _repo;
        public LogradouroService(ILogradouroRepository repo){
            _repo = repo;
        }

        public Task<IEnumerable<Logradouro>> GetAllLogradourosAsync() => _repo.GetAllAsync();
        public Task<Logradouro?> GetLogradouroByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task CreateLogradouroAsync(Logradouro newLogradouro) => _repo.CreateAsync(newLogradouro);
        public Task<bool> UpdateLogradouroAsync(int id, Logradouro updatedLogradouro) => _repo.UpdateAsync(id, updatedLogradouro);
        public Task<bool> DeleteLogradouroAsync(int id) => _repo.DeleteAsync(id);
    }
}
