using ExpertDirectory.Application.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertDirectory.Application.Features.Users.Queries.GetMembers
{
    public class GetAllMembersQuery  : IRequest<List<MemberListDTO>>
    {

    }
}
