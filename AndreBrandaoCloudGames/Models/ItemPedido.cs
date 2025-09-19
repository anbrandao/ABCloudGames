using AndreBrandaoCloudGamesApi.Repositories.Contracts;

namespace AndreBrandaoCloudGamesApi.Models
{
    public class ItemPedido : BaseEntity
    {
        public Guid PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
        public Guid JogoId { get; set; }
        public Jogo? Jogo { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public void DefinirPrecoUnitario(decimal PrecoVenda)
        {
            this.PrecoUnitario = PrecoVenda;

        }
    }
}


