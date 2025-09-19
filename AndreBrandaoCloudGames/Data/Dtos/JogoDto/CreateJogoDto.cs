using AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto;
using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto
{
    public class CreateJogoDto
    {
        public required string Titulo { get; set; }
        public decimal Preco { get; set; }
        public bool IsPromotional { get; set; }
    }
}
