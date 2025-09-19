using AndreBrandaoCloudGamesApi.Repositories.Contracts;

namespace AndreBrandaoCloudGamesApi.Models
{
    /// <summary>
    /// Representa um jogo disponível na plataforma, contendo informações como título,
    /// preço e status promocional.
    /// </summary>
    public class Jogo : BaseEntity, IPromocaoObserver
    {
        public required string Titulo { get; set; } 
        public decimal Preco { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool IsPromotional { get; set; }

         public ICollection<ItemPedido> ItensPedidos { get; set; } = new List<ItemPedido>();
       
        public void AtualizarPromocao(bool IsPromotional)
        {
            var config = new ConfiguracaoPromocao();

            if (IsPromotional)
            {
                PrecoVenda = decimal.Multiply(Preco, config.FatorDescontoPromocional);
                AtualizarIsPromotional(IsPromotional);
            }
            else
            {
                PrecoVenda = Preco;
                AtualizarIsPromotional(IsPromotional);
            }
        }

        public void AtualizarIsPromotional(bool IsPromotional)
        {
           this.IsPromotional = IsPromotional;
        }
    }

}
