namespace AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto
{
    public class CreateItemPedidoDto
    {
        public Guid PedidoId { get; set; }
        public Guid JogoId { get; set; }
        public int Quantidade { get; set; }

    }

}
