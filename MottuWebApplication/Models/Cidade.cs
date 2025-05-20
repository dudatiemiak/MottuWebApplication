using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Cidade
    {
        [Key]
        public int IdCidade { get; set; }

        [Required, StringLength(50)]
        public string NmCidade { get; set; }

        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
