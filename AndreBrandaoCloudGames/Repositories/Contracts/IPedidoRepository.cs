using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Repository;

namespace AndreBrandaoCloudGamesApi.Repositories.Contracts
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Task<Pedido> GetDetalhesDoPedidoAsync(Guid id);
    }
}
