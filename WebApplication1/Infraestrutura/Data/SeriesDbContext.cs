using Microsoft.EntityFrameworkCore;
using SeriesApp.Business.Entities;
using SeriesApp.Infraestrutura.Data.Mappings;

namespace SeriesApp.Infraestrutura.Data
{
    public class SeriesDbContext : DbContext
    {
        public SeriesDbContext(DbContextOptions<SeriesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SeriesMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }


        // FUNCAO QUE CRIA O USUARIO
        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Series> Series { get; set; }

    }
}
