using EcoFiap.Models;
using EcoFiap.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EcoFiap.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ColetorModel> Coletor { get; set; }
        // Propriedade que será responsável pelo acesso a tabela de Usuarios
        public DbSet<UsuarioModel> Usuario { get; set; }

        public DbSet<AvaliacaoModel> Avaliacao { get; set; }

        public DbSet<ColetaModel> Coleta { get; set; }

        public DbSet<GeolocalizacaoModel> Geolocalizacao { get; set; }


    }
}
