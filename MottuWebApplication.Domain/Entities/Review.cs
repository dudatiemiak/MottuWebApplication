using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuWebApplication.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public float KmRodados { get; set; }
        public float DiasDesdeUltimaManutencao { get; set; }
        public string? PredictedManutencao { get; set; }
        public float? ManutencaoScore { get; set; }

    }
}
