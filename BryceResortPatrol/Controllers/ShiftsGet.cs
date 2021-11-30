﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BryceResortPatrol.Controllers.Schedule
{
    [Route("api/shifts/year/{year}")]
    [ApiController]
    public class ShiftsGet : BaseApiController
    {
        public ShiftsGet(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]ShiftsGetQuery shiftsGetQuery) => Ok(await this.mediator.Send(shiftsGetQuery).ConfigureAwait(false));
    }
}
