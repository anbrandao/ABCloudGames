using AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto;
using AndreBrandaoCloudGamesApi.Identity;
using AndreBrandaoCloudGamesApi.Infraestrutura;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AndreBrandaoCloudGamesApi.Repositories.Repository
{
    public class ItemPedidoRepository : GenericRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ItemPedido> GetDetalhesDoItemPedidoAsync(Guid id)
        {
          
                var itemPedido = await _context.ItemPedidos
                    .Include(ip => ip.Pedido)
                        .ThenInclude(p => p.Usuario)
                    .Include(ip => ip.Jogo)
                        .ThenInclude(p => p.ItensPedidos)
                    .FirstOrDefaultAsync(j => j.Id == id);

                    itemPedido.Pedido.Usuario.Pedidos = null;
                    itemPedido.Pedido.ItensPedidos = null;
                    itemPedido.Jogo.ItensPedidos = null;

            return itemPedido;

        }
    }
}
