using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BryceResortPatrol.Controllers
{
    [ApiController]
    [Route("api/join")]
    public class JoinPostController : BaseApiController
    {
        public JoinPostController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] JoinPostCommand joinPostCommand) => Ok(await this.mediator.Send(joinPostCommand));
    }
}