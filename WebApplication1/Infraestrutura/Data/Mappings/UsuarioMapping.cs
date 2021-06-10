using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeriesApp.Business.Entities;

namespace SeriesApp.Infraestrutura.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO"); // Criando a tabela de usuario
            builder.HasKey(p => p.Codigo); // setando codigo como Chave primaria
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd(); // Configuracao de auto incremento 
            builder.Property(p => p.Login);
            builder.Property(p => p.Senha);
            builder.Property(p => p.Email);
        }
    }
}
