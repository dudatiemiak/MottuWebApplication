using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Manutencao
    {
        [Key]
        public int IdManutencao { get; set; }

        [Required]
        public DateTime DtEntrada { get; set; }

        public DateTime? DtSaida { get; set; }

        [Required, StringLength(300)]
        public string DsManutencao { get; set; }

        public int IdMoto { get; set; }
        [ForeignKey("IdMoto")]
        public Moto Moto { get; set; }
    }
}
