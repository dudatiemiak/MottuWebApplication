using MottuWebApplication.Application.Interfaces;
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

        public Task<IEnumerable<Moto>> GetAllMotosAsync() => _repo.GetAllAsync();

        public Task<Moto?> GetMotoByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task CreateMotoAsync(Moto newMoto)
        {
            if (string.IsNullOrWhiteSpace(newMoto.NmPlaca)) throw new ArgumentException("A placa é obrigatória.");
            if (!string.IsNullOrEmpty(newMoto.NmPlaca) && newMoto.NmPlaca.Length > 10) throw new ArgumentException("A placa não pode ter mais que 10 caracteres.");
            if (string.IsNullOrWhiteSpace(newMoto.StMoto)) throw new ArgumentException("O status da moto é obrigatório.");
            if (newMoto.KmRodado < 0) throw new ArgumentException("O km rodado não pode ser negativo.");
            await _repo.CreateAsync(newMoto);
        }

        public Task<bool> UpdateMotoAsync(int id, Moto updatedMoto) => _repo.UpdateAsync(id, updatedMoto);

        public Task<bool> DeleteMotoAsync(int id) => _repo.DeleteAsync(id);

        public Task<IEnumerable<Moto>> GetByPlacaAsync(string placa)
            => _repo.GetByPlacaAsync(placa);

        public Task<IEnumerable<Moto>> GetByStatusAsync(string status)
            => _repo.GetByStatusAsync(status);

        public Task<IEnumerable<Moto>> GetByFilialDepartamentoAsync(int idFilialDepartamento)
            => _repo.GetByFilialDepartamentoAsync(idFilialDepartamento);
    }
}
