using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Repositories.Contracts
{
    public interface IItemPedidoRepository : IGenericRepository<ItemPedido>
    {
        Task<ItemPedido> GetDetalhesDoItemPedidoAsync(Guid id);
    }
}
