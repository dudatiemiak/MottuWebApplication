using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }

        [Required]
        public string NmEstado { get; set; }

        public int IdPais { get; set; }
        [ForeignKey("IdPais")]
        public Pais? Pais { get; set; }
    }
}
