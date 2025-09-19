using AndreBrandaoCloudGamesApi.ExceptionsBase;
using FluentValidation;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
    public class RegistraUsuarioUseCase
    {
        public ReadUsuarioDto Execute(CreateUsuarioDto createUsuarioDto)
        {
            Validate(createUsuarioDto);
            return new ReadUsuarioDto
            {
                Nome = createUsuarioDto.Nome
            };
        }

        private void Validate(CreateUsuarioDto createUsuarioDto)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(createUsuarioDto);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
