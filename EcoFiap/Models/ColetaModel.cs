namespace EcoFiap.Models
{
    public class ColetaModel
    {
        public int ColetaId { get; set; }
        public bool TipoResiduo { get; set; }

        public DateTime DataHoraAgendada { get; set; }

        public string Endereco { get; set; }

        public ColetaModel(string endereco)
        {
            Endereco = endereco;
        }

        public UsuarioModel? UsuarioId { get; set; }

        public ColetorModel? ColetorId { get; set; }

    }
}
