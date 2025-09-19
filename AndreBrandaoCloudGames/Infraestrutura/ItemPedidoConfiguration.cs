using AndreBrandaoCloudGamesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreBrandaoCloudGamesApi.Infraestrutura
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.PrecoUnitario).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(e => e.Quantidade).IsRequired();

            builder.HasOne(j => j.Jogo).
            WithMany(e => e.ItensPedidos).
            HasPrincipalKey(e => e.Id).
            HasForeignKey(e => e.JogoId).
            OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Pedido).
            WithMany(u => u.ItensPedidos).
            HasPrincipalKey(e => e.Id).
            HasForeignKey(e => e.PedidoId).
            OnDelete(DeleteBehavior.Restrict);
        }
    }
}
