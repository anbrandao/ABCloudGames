using AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto;
using AndreBrandaoCloudGamesApi.ExceptionsBase;
using AndreBrandaoCloudGamesApi.Models;
using FluentValidation;
namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
   
    public class RegisterUserValidator : AbstractValidator<CreateUsuarioDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD);

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD)
                .EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD)
                .MinimumLength(6).WithMessage(ResourceMessagesException.PASSWORD_MIN_LENGTH)
                .Matches(@"[A-Z]").WithMessage(ResourceMessagesException.PASSWORD_UPPERCASE_REQUIRED)
                .Matches(@"[a-z]").WithMessage(ResourceMessagesException.PASSWORD_LOWERCASE_REQUIRED)
                .Matches(@"\d").WithMessage(ResourceMessagesException.PASSWORD_NUMBER_REQUIRED)
                .Matches(@"[\W_]").WithMessage(ResourceMessagesException.PASSWORD_SPECIAL_CHAR_REQUIRED);



            RuleFor(u => u.Repassword)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD)
                .Equal(u => u.Password).WithMessage(ResourceMessagesException.PASSWORDS_DO_NOT_MATCH);

            RuleFor(u => u.Role)
                .NotEmpty().WithMessage(ResourceMessagesException.REQUIRED_FIELD);
        }
    }
}
