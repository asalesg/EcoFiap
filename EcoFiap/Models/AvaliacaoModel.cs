using System.Security.Principal;

namespace EcoFiap.Models
{
    public class AvaliacaoModel
    {
        public int AvaliacaoId { get; set; }

        public int Nota { get; set; }

        public string? Comentario { get; set; }

        public UsuarioModel? UsuarioId { get; set; }

        public ColetorModel? ColetorId { get; set; }
    }
}
