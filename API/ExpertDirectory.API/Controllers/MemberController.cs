using ExpertDirectory.Application.Features.Users.Commands.AddUser;
using ExpertDirectory.Application.Features.Users.Commands.UpdateConnection;
using ExpertDirectory.Application.Features.Users.Queries.GetMemberProfile;
using ExpertDirectory.Application.Features.Users.Queries.GetMembers;
using ExpertDirectory.Application.Models.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        #region Field
        private readonly IMediator _mediator; 
        #endregion

        #region Construtor
        public MemberController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region APIs
        /// <summary>
        ///    GetMemberList
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet(Name = "[action]")]
        [ProducesResponseType(typeof(List<MemberListDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MemberListDTO>>> GetMemberList()
        {
            var result = await _mediator.Send(new GetAllMembersQuery());
            return Ok(result);
        }

        /// <summary>
        ///    GetMemberProfile
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{userId}",Name = "[action]")]
        [ProducesResponseType(typeof(MemberProfileDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MemberProfileDTO>> GetMemberProfile(long userId)
        {
            var result = await _mediator.Send(new GetMemberProfileQuery { UserId = userId});
            return Ok(result);
        }
        /// <summary>
        ///   AddMemberUser
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddMemberUser")]
        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddMemberUser([FromBody] AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateMemberUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpdateMemberUser([FromBody] UpdateConnectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        } 
        #endregion
    }
}
