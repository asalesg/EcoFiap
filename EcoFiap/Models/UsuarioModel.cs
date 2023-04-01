using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoFiap.Models
{
    public class UsuarioModel
    {
        [Key]
        [Column("USUARIOID")]
        public int UsuarioId { get; set; }

        public string Nome { get; set; }
        
        public string Endereco { get; set; }


        public string email { get; set; }

        public string Telefone { get; set; }


    }

    
}
