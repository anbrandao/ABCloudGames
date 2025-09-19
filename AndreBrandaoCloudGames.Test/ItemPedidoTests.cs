using AndreBrandaoCloudGamesApi.Models;
using Bogus;

namespace AndreBrandaoCloudGames.Test
{

    public class ItemPedidoTests
    {
        [Fact]
        public void DefinirPrecoUnitario_DeveAtualizarPrecoUnitario()
        {
            // Arrange
            var faker = new Faker(); 
            var preco = faker.Random.Decimal(10, 100);

            var item = new ItemPedido();

            //Act
            item.DefinirPrecoUnitario(preco);


            //Assert
            Assert.Equal(preco, item.PrecoUnitario);
        }
    }
}

