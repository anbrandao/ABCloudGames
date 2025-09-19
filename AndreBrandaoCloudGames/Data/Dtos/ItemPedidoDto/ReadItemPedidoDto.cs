using AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.PedidoDto;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto
{
    public class ReadItemPedidoDto : CreateItemPedidoDto
    {
        public Guid Id { get; set; }
        public string? CreatedDate { get; set; }
        public ReadJogoDto Jogo { get; set; }
        public ReadPedidoDto Pedido { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalDoItem => Quantidade * PrecoUnitario;
    }
}
