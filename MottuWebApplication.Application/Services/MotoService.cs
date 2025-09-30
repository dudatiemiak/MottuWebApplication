using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _repo;

        public MotoService(IMotoRepository repo)
        {
            _repo = repo;
        }

        public Task<IReadOnlyList<Moto>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Moto?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Moto> CreateAsync(Moto moto)
        {
            if (string.IsNullOrWhiteSpace(moto.NmPlaca)) throw new ArgumentException("A placa é obrigatória.");
            if (!string.IsNullOrEmpty(moto.NmPlaca) && moto.NmPlaca.Length > 10) throw new ArgumentException("A placa não pode ter mais que 10 caracteres.");
            if (string.IsNullOrWhiteSpace(moto.StMoto)) throw new ArgumentException("O status da moto é obrigatório.");
            if (moto.KmRodado < 0) throw new ArgumentException("O km rodado não pode ser negativo.");
            return await _repo.CreateAsync(moto);
        }

    public Task UpdateAsync(Moto moto) => _repo.UpdateAsync(moto);

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

        public Task<IReadOnlyList<Moto>> GetByPlacaAsync(string placa)
            => _repo.GetByPlacaAsync(placa);

        public Task<IReadOnlyList<Moto>> GetByStatusAsync(string status)
            => _repo.GetByStatusAsync(status);

        public Task<IReadOnlyList<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento)
            => _repo.GetByFilialDepartamentoAsync(idFilialDepartamento);
    }
}
