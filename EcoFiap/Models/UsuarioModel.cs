using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoFiap.Models
{
    [Table("USUARIO")]
    public class UsuarioModel
    {

        [Key]
        [Column("USUARIOID")]
        public int UsuarioId { get; set; } //sulfixo Id exclui a NECESSIDADE da notação key porem uso pra ostentar

        [Column("NOMEUSUARIO")]
        [Required(ErrorMessage ="Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column("ENDERECOUSUARIO")]
        [Required(ErrorMessage = "Endereço é obrigatório!")]
        [StringLength(100, MinimumLength = 10, ErrorMessage ="O endereço deve ter, no minimo 10 e, no máximo, 100 caracteres")]
        public string? Endereco { get; set; }

        [Column("EMAILSUARIO")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? email { get; set; }

        [Column("TELEFONEUSUARIO")]
        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? Telefone { get; set; }

        
    }

    
}
