using System.Security.Principal;

namespace EcoFiap.Models
{
    public class AvaliacaoModel
    {
        public AvaliacaoModel()
        {
        }

        public AvaliacaoModel(int avaliacaoId, int nota, string? comentario)
        {
            AvaliacaoId = avaliacaoId;
            Nota = nota;
            Comentario = comentario;
        }

        public int AvaliacaoId { get; set; }

        public int Nota { get; set; }

        public string? Comentario { get; set; }

        public ICollection<UsuarioModel> Usuarios { get; set; } = new List<UsuarioModel>();

        public ICollection<ColetorModel> Coletors { get; set; } = new List<ColetorModel>();
    }
}
