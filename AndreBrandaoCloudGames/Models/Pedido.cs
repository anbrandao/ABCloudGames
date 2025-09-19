using Bogus.DataSets;

namespace AndreBrandaoCloudGamesApi.Models
{
    public class Pedido : BaseEntity
    {
        /// <summary>
        /// Representa um pedido realizado na plataforma de jogos, contendo o usuário responsável pela compra,
        /// a lista de jogos adquiridos e o valor total do pedido.
        public string? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public ICollection<ItemPedido> ItensPedidos { get; set; } = new List<ItemPedido>();
        public decimal CalcularTotal()
        {
            return ItensPedidos.Sum(i => i.Quantidade * i.PrecoUnitario);
        }

    }
}
