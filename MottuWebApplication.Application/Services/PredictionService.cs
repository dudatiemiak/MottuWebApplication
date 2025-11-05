using Microsoft.Extensions.ML;
using MottuWebApplication.Domain.Entities;
using MottuWebApplication.MottuWebApplication.Domain.Entities;

namespace MottuWebApplication.Application.Services
{
    public class PredictionService : IPredictionService
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _pool;
        private const string ModelName = "DefaultModelName";

        public PredictionService(PredictionEnginePool<ModelInput, ModelOutput> pool)
        {
            _pool = pool;
        }

        public ModelOutput PredictManutencao(ModelInput input)
        {
            return _pool.Predict(ModelName, input);
        }
    }
}

