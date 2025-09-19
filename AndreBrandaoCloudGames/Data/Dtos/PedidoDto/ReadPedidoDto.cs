using AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto;
using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.PedidoDto
{
    public class ReadPedidoDto : CreatePedidoDto
    {
        public Guid Id { get; set; }
        public string? CreatedDate { get; set; } 
        public ReadUsuarioDto? Usuario { get; set; }
        public ICollection<ReadItemPedidoDto> ItensPedidos { get; set; } = new List<ReadItemPedidoDto>();
        public decimal TotalPedido => ItensPedidos.Sum(i => i.TotalDoItem);
        public int TotalItens {  get; set; }
    }
}
