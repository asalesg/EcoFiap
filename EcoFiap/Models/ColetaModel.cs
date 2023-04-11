using EcoFiap.Models.Enums;

namespace EcoFiap.Models
{
    public class ColetaModel
    {
        public ColetaModel()
        {
        }

        public ColetaModel(int coletaId, TipoResiduo tipo, DateTime dataHoraAgendada, string? endereco)
        {
            ColetaId = coletaId;
            Tipo = tipo;
            DataHoraAgendada = dataHoraAgendada;
            Endereco = endereco;
        }

        public int ColetaId { get; set; }
        public TipoResiduo Tipo { get; set; }

        public DateTime DataHoraAgendada { get; set; }

        public string? Endereco { get; set; }

        public ICollection<UsuarioModel> Usuarios { get; set; } = new List<UsuarioModel>();

        public ICollection<ColetorModel> Coletors { get; set; } = new List<ColetorModel>();
    }
}
