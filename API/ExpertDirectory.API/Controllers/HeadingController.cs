using ExpertDirectory.Application.Features.Headings.Queries;
using ExpertDirectory.Application.Models.MemberConnection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeadingController : ControllerBase
    {
        #region Field
        private readonly IMediator _mediator;
        #endregion

        #region Construtor
        public HeadingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region APIs

        /// <summary>
        ///    SeachHeadings
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet(Name = "[action]")]
        [ProducesResponseType(typeof(List<MemberSearchDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MemberSearchDTO>>> SearchHeading([FromQuery]HeadingSearchQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        #endregion
    }
}
