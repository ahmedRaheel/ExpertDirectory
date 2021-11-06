using ExpertDirectory.Application.Models.MemberConnection;
using MediatR;
using System.Collections.Generic;

namespace ExpertDirectory.Application.Features.Headings.Queries
{
    public class HeadingSearchQuery : IRequest<List<MemberSearchDTO>>
    {
        public long UserId { get; set; }
        public string SearchTerm { get; set; }
    }
}
