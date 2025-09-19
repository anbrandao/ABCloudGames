using AndreBrandaoCloudGamesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreBrandaoCloudGamesApi.Infraestrutura
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
           
            builder.ToTable("Usuario");
            builder.Property(e => e.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.Email).HasColumnName("Email").HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.Role).HasConversion<string>().HasColumnType("VARCHAR(100)").IsRequired();
           
        }
    }
}
