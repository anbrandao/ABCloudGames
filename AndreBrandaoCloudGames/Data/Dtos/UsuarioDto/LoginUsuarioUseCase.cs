using AndreBrandaoCloudGamesApi.ExceptionsBase;
using FluentValidation;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
    public class LoginUsuarioUseCase
    {
        public ReadUsuarioDto Execute(LoginUsuarioDto loginUsuarioDto)
        {
            Validate(loginUsuarioDto);
            return new ReadUsuarioDto
            {
                Nome = loginUsuarioDto.UserName
            };
        }

        private void Validate(LoginUsuarioDto loginUsuarioDto)
        {
            var validator = new LoginUserValidator();
            var result = validator.Validate(loginUsuarioDto);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}