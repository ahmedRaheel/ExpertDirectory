using MediatR;
using System.Collections.Generic;

namespace ExpertDirectory.Application.Features.Users.Commands.UpdateConnection
{
    public class UpdateConnectionCommand  : IRequest<long>
    {
        #region Properties

        public long UserId { get; set; }
        public List<long> ConnectionIds { get; set; }
        #endregion

        #region Constructor
        public UpdateConnectionCommand()
        {
            ConnectionIds = new List<long>();
        }
        #endregion          
    }
}
