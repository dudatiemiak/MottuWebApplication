using MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public interface IPredictionService
    {
        ModelOutput PredictManutencao(ModelInput input);
    }
}
