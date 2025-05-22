using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Bairro
    {
        [Key]
        public int IdBairro { get; set; }

        [Required, StringLength(100)]
        public string NmBairro { get; set; }

        public int IdCidade { get; set; }
        [ForeignKey("IdCidade")]
        public Cidade? Cidade { get; set; }
    }
}
