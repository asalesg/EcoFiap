namespace EcoFiap.Models
{
    public class GeolocalizacaoModel
    {
        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public UsuarioModel? UsuarioId { get; set; }

        public ColetorModel? ColetorId { get; set; }
    }
}
