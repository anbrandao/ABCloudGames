namespace AndreBrandaoCloudGames.Test
{
    using AndreBrandaoCloudGamesApi.Models;
    using Bogus;
    using Xunit;

    public class JogoBehaviorTests
    {
        [Fact]
        public void DadoQueUmJogoEstaEmPromocao_QuandoAtualizarPromocao_EntaoPrecoVendaDeveSerComDesconto()
        {
            // Dado
            var faker = new Faker();
            var precoOriginal = faker.Random.Decimal(50, 200);
            var config = new ConfiguracaoPromocao();
            var jogo = new Jogo { Titulo = faker.Commerce.ProductName(), Preco = precoOriginal };

            // Quando
            jogo.AtualizarPromocao(true);

            // Então
            Assert.Equal(precoOriginal * config.FatorDescontoPromocional, jogo.PrecoVenda);
            Assert.True(jogo.IsPromotional);
        }

        [Fact]
        public void DadoQueUmJogoNaoEstaMaisEmPromocao_QuandoAtualizarPromocao_EntaoPrecoVendaDeveSerRestaurado()
        {
            // Dado
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

            // Quando
            jogo.AtualizarPromocao(false);

            // Então
            Assert.Equal(precoOriginal, jogo.PrecoVenda);
            Assert.False(jogo.IsPromotional);
        }
    }
}