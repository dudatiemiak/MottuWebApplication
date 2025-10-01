using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<Modelo>> GetAllModelosAsync();
        Task<Modelo?> GetModeloByIdAsync(int id);
        Task CreateModeloAsync(Modelo newModelo);
        Task<bool> UpdateModeloAsync(int id, Modelo updatedModelo);
        Task<bool> DeleteModeloAsync(int id);
    }
}
