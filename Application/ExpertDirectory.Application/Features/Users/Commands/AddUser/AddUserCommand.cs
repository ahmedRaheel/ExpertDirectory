using ExpertDirectory.Application.Models.User;
using MediatR;

namespace ExpertDirectory.Application.Features.Users.Commands.AddUser
{
    public class AddUserCommand  : IRequest<UserDTO>
    {
        public string UserName { get; set; }
        public string PersonalWeb { get; set; }
    }
}
