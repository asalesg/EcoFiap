using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoFiap.Models
{
    [Table("COLETOR")]
    public class ColetorModel
    {
        public ColetorModel()
        {
        }


        public ColetorModel(int coletorId, string? nome, string? endereco, string? email, string? telefone)
        {
            ColetorId = coletorId;
            Nome = nome;
            Endereco = endereco;
            this.email = email;
            Telefone = telefone;
        }

        [Key]
        [Column("COLETORID")]
        public int ColetorId { get; set; }

        [Column("NOMECOLETOR")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column("ENDERECOCOLETOR")]
        [Required(ErrorMessage = "Endereco é obrigatório!")]

        public string? Endereco { get; set; }

        [Column("EMAILCOLETOR")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? email { get; set; }

        [Column("TELEFONECOLETOR")]
        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? Telefone { get; set; }
    }
}
