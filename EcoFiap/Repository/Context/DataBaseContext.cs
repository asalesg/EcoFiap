using EcoFiap.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EcoFiap.Repository.Context
{
    public class DataBaseContext : DbContext
    {

        // Propriedade que será responsável pelo acesso a tabela de Usuarios
        public DbSet<UsuarioModel> Usuario { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DataBaseContext()
        {
        }
        public DbSet<EcoFiap.Models.ColetorModel>? ColetorModel { get; set; }
    }
}
