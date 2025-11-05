using Microsoft.ML.Data;


namespace MottuWebApplication.Trainer
{
    /// <summary>
    /// Classe de entrada para o modelo de manutenção de motos.
    /// </summary>
    public class ModelInput
    {
        // Coluna 0: Quilometragem rodada
        [LoadColumn(0)]
        public float KmRodados { get; set; }

        // Coluna 1: Dias desde a última manutenção
        [LoadColumn(1)]
        public float DiasDesdeUltimaManutencao { get; set; }

        // Coluna 2: Label (precisa de manutenção)
        [LoadColumn(2), ColumnName("Label")]
        public bool PrecisaManutencao { get; set; }
    }

}
