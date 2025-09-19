namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
    using AndreBrandaoCloudGamesApi.ExceptionsBase;
    using FluentValidation;

    public class LoginUserValidator : AbstractValidator<LoginUsuarioDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD);
        }
    }
}
