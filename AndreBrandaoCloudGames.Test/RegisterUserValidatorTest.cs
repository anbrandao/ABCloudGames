using AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto;
using Bogus;

namespace AndreBrandaoCloudGames.Test
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Validate_DeveRetornarValido_QuandoDadosEstaoCorretos()
        {
            // Arrange
            var faker = new Faker();

            var dto = new CreateUsuarioDto
            {
                Nome = faker.Person.FirstName,
                Email = faker.Internet.Email(),
                UserName = faker.Internet.UserName(),
                Role = faker.PickRandom(new[] { "User", "Admin" }),
                Password = "Senha@123", 
                Repassword = "Senha@123"
            };

            var validator = new RegisterUserValidator();

            // Act
            var result = validator.Validate(dto);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}

