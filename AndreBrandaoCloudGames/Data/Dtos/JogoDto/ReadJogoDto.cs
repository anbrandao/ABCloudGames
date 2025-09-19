using AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.PedidoDto;
using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto
{
    public class ReadJogoDto : CreateJogoDto
    {
        public Guid Id { get; set; }
        public string? CreatedDate { get; set; }
        public decimal PrecoVenda { get; set; }
        public ICollection<ReadItemPedidoDto> ItensPedidos { get; set; } = new List<ReadItemPedidoDto>();
    }
}
