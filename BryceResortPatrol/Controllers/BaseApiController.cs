using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BryceResortPatrol.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IMediator mediator;

        public BaseApiController(IMediator mediator) => this.mediator = mediator;
    }
}
