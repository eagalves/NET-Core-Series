using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SeriesApp.Infraestrutura.Data;

namespace SeriesApp.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<SeriesDbContext>
    {
        public SeriesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SeriesDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CURSO;Trusted_Connection=True");
            SeriesDbContext contexto = new SeriesDbContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
