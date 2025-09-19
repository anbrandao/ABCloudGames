using AndreBrandaoCloudGamesApi.Models;
using Bogus;

namespace AndreBrandaoCloudGames.Test
{
    using AndreBrandaoCloudGamesApi.Models;
    using Bogus;
    using Xunit;

    public class JogoTests
    {
        [Fact]
        public void AtualizarPromocao_DeveAplicarDesconto_QuandoPromocional()
        {
            // Arrange
            var faker = new Faker();
            var precoOriginal = faker.Random.Decimal(50, 200);
            var config = new ConfiguracaoPromocao();

            var jogo = new Jogo { Titulo = faker.Commerce.ProductName(), Preco = precoOriginal };

            // Act
            jogo.AtualizarPromocao(true);

            // Assert
            Assert.Equal(precoOriginal * config.FatorDescontoPromocional, jogo.PrecoVenda);
            Assert.True(jogo.IsPromotional);
        }


        [Fact]
        public void AtualizarPromocao_DeveRemoverDesconto_QuandoNaoPromocional()
        {
            // Arrange
            var faker = new Faker();
            var precoOriginal = faker.Random.Decimal(50, 200);
            var config = new ConfiguracaoPromocao(); 

            var jogo = new Jogo
            {
                Titulo = faker.Commerce.ProductName(),
                Preco = precoOriginal,
                PrecoVenda = precoOriginal * config.FatorDescontoPromocional,
                IsPromotional = true
            };

            // Act
            jogo.AtualizarPromocao(false);

            // Assert
            Assert.Equal(precoOriginal, jogo.PrecoVenda);
            Assert.False(jogo.IsPromotional);
        }
    }
}