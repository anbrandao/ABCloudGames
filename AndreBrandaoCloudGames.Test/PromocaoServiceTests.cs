using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using AndreBrandaoCloudGamesApi.Services;
using Bogus;
using Moq;

namespace AndreBrandaoCloudGames.Test
{

    public class PromocaoServiceTests
    {
        [Fact]
        public async Task AtualizaJogosAplicandoDesconto_DeveAplicarDescontoEmTodosOsJogos()
        {
            // Arrange
            var faker = new Faker();
            var config = new ConfiguracaoPromocao(); 

            var jogos = new List<Jogo>
        {
            new Jogo { Titulo = faker.Commerce.ProductName(), Preco = 100m },
            new Jogo { Titulo = faker.Commerce.ProductName(), Preco = 200m }
        };

            var jogoRepositoryMock = new Mock<IJogoRepository>();

            jogoRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(jogos);
            jogoRepositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Jogo>())).Returns(Task.CompletedTask);
            var implementacaoFakeDeIJogoRepository = jogoRepositoryMock.Object;

            var promocaoService = new PromocaoService(implementacaoFakeDeIJogoRepository);

            // Act
            await promocaoService.AtualizaJogosAplicandoDesconto(true);

            // Assert
            Assert.All(jogos, jogo =>
                Assert.Equal(jogo.Preco * config.FatorDescontoPromocional, jogo.PrecoVenda));

            jogoRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Jogo>()), Times.Exactly(jogos.Count));
        }
    }
}
