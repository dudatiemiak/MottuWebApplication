using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class FilialDepartamento
    {
        [Key]
        public int IdFilialDepartamento { get; set; }

        public int IdFilial { get; set; }
        public int IdDepartamento { get; set; }

        [ForeignKey("IdFilial")]
        public Filial Filial { get; set; }

        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set; }

        public DateTime DtEntrada { get; set; }
        public DateTime? DtSaida { get; set; }
    }
}
