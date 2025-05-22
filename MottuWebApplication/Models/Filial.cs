using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Filial
    {
        [Key]
        public int IdFilial { get; set; }

        [Required, StringLength(100)]
        public string NmFilial { get; set; }

        public int IdLogradouro { get; set; }
        [ForeignKey("IdLogradouro")]
        public Logradouro? Logradouro { get; set; }
    }
}
