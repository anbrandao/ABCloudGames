using AndreBrandaoCloudGamesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreBrandaoCloudGamesApi.Infraestrutura
{
    public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
           
            builder.ToTable("Jogo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(e => e.Titulo).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.Preco).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(e => e.PrecoVenda).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(e => e.IsPromotional).HasColumnType("BIT").IsRequired();

            builder.HasMany(p => p.ItensPedidos)
                .WithOne(i => i.Jogo)
                .HasForeignKey(i => i.JogoId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
