using AndreBrandaoCloudGamesApi.Data.Dtos.PedidoDto;
using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
    public class ReadUsuarioDto 
    {
        public string Nome { get; set; }
        public string? Id { get; set; }
        public string? CreatedDate { get; set; }
        public string Role { get; set; }
        public ICollection<ReadPedidoDto> Pedidos { get; set; } = new List<ReadPedidoDto>();
    }
}
