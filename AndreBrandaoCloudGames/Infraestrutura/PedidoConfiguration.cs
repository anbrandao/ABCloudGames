using AndreBrandaoCloudGamesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AndreBrandaoCloudGamesApi.Infraestrutura
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(e => e.Id);

            builder.HasOne(p=> p.Usuario).
            WithMany(u => u.Pedidos).
            HasPrincipalKey(u => u.Id).
            HasForeignKey(p => p.UsuarioId).
            OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.ItensPedidos).
            WithOne(i => i.Pedido).
            HasPrincipalKey(e => e.Id).
            HasForeignKey(i => i.PedidoId).
            OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
