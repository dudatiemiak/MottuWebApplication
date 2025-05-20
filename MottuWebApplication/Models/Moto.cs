using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Moto
    {
        [Key]
        public int IdMoto { get; set; }

        [Required, StringLength(10)]
        public string NmPlaca { get; set; }

        [Required, StringLength(30)]
        public string StMoto { get; set; }

        public double KmRodado { get; set; }

        public int IdCliente { get; set; }
        public int IdModelo { get; set; }
        public int IdFilialDepartamento { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdModelo")]
        public Modelo Modelo { get; set; }

        [ForeignKey("IdFilialDepartamento")]
        public FilialDepartamento FilialDepartamento { get; set; }
    }
}
