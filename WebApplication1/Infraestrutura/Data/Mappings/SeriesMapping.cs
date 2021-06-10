using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesApp.Business.Entities;


namespace SeriesApp.Infraestrutura.Data.Mappings
{
    public class SeriesMapping : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.ToTable("TB_SERIES");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo);
            builder.Property(p => p.Genero);
            builder.Property(p => p.Descricao);
            builder.Property(p => p.Ano);
            builder.Property(p => p.Excluido);
        }
    }
}
