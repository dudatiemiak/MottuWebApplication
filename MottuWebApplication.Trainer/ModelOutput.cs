using Microsoft.ML.Data;

namespace MottuWebApplication.Trainer
{
    /// <summary>
    /// Classe de saída do modelo de manutenção de motos.
    /// </summary>
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public bool PredicaoPrecisaManutencao { get; set; }
        public float Score { get; set; }
    }

}
