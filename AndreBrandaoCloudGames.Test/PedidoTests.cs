using AndreBrandaoCloudGamesApi.Models;
using Bogus;

namespace AndreBrandaoCloudGames.Test
{

    public class PedidoTests
    {
        [Fact]
        public void CalcularTotal_DeveRetornarSomaDosItens()
        {
            // Arrange
            var faker = new Faker();

            var pedido = new Pedido();
            pedido.ItensPedidos.Add(new ItemPedido
            {
                Quantidade = faker.Random.Int(1, 5),
                PrecoUnitario = faker.Random.Decimal(10m, 100m)
            });

            pedido.ItensPedidos.Add(new ItemPedido
            {
                Quantidade = faker.Random.Int(1, 5),
                PrecoUnitario = faker.Random.Decimal(10m, 100m)
            });

            var expectedTotal = pedido.ItensPedidos.Sum(i => i.Quantidade * i.PrecoUnitario);

            // Act
            var total = pedido.CalcularTotal();


            // Assert
            Assert.Equal(expectedTotal, total);
        }
    }
}

