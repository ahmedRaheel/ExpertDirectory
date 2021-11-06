using FluentValidation;

namespace ExpertDirectory.Application.Features.Users.Commands.UpdateConnection
{
    public class UpdateConnectionValidator : AbstractValidator<UpdateConnectionCommand>
    {
        public UpdateConnectionValidator() 
        {
            RuleFor(r => r.UserId)
                .NotEmpty().WithMessage("UserId is required ");
            RuleFor(r => r.ConnectionIds)
                .NotEmpty().WithMessage("Connection Id is required");
        }
    }
}
