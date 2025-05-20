using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MottuWebApplication.Models
{
    public class Logradouro
    {
        [Key]
        public int IdLogradouro { get; set; }

        [Required, StringLength(100)]
        public string NmLogradouro { get; set; }

        [Required, StringLength(10)]
        public string NrLogradouro { get; set; }

        [StringLength(100)]
        public string NmComplemento { get; set; }

        public int IdBairro { get; set; }
        [ForeignKey("IdBairro")]
        public Bairro Bairro { get; set; }

        public List<Cliente> Clientes { get; set; }
        public List<Filial> Filiais { get; set; }
    }
}
