using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace EcoFiap.Models
{
    public class GeolocalizacaoModel
    {
        public GeolocalizacaoModel()
        {
        }

        public GeolocalizacaoModel(string? latitude, string? longitude, UsuarioModel? usuarioId, ColetorModel? coletorId)
        {
            Latitude = latitude;
            Longitude = longitude;
            UsuarioId = usuarioId;
            ColetorId = coletorId;
        }
        [Key]
        public  int LocalizaçãoId { get; set; }
        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public UsuarioModel? UsuarioId { get; set; }

        public ColetorModel? ColetorId { get; set; }
    }
}
