using Microsoft.ML.Data;

namespace MottuWebApplication.Domain.Entities
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public bool PredicaoPrecisaManutencao { get; set; }
        public float Score { get; set; }
    }
}
