using FluentValidation;

namespace ExpertDirectory.Application.Features.Users.Commands.AddUser
{
    public class AdddUserValidator  :  AbstractValidator<AddUserCommand>
    {
        public AdddUserValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotNull();                

            RuleFor(p => p.PersonalWeb)
               .NotEmpty().WithMessage("{Personal Web URL} is required.");
        }
    }
}
