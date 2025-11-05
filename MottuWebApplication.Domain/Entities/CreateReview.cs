using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace MottuWebApplication.Domain.Entities
{
    public class CreateReview
    {
        public float KmRodados { get; set; }
        public float DiasDesdeUltimaManutencao { get; set; }
    }
}
