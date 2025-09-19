using AndreBrandaoCloudGamesApi.Infraestrutura;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AndreBrandaoCloudGamesApi.Repositories.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Pedido> GetDetalhesDoPedidoAsync(Guid id)
        {
            var pedido = await _context.Pedidos.
                Include(p => p.Usuario)
                .Include(p => p.ItensPedidos).
                    ThenInclude(ip => ip.Jogo)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            pedido.Usuario.Pedidos = null;

            pedido.ItensPedidos = pedido.ItensPedidos
                .Select(p =>
                {
                    p.Pedido = null;
                    p.Jogo.ItensPedidos = null;
                    return p;
                })
                .Distinct()
                .ToList();

            return pedido;
        }
    }
}
