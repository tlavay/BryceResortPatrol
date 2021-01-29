using BryceResortPatrol.Common.Models;
using BryceResortPatrol.Common.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BryceResortPatrol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoinController : ControllerBase
    {
        private readonly IJoinRepository joinRepository;
        //private readonly ILogger logger;

        public JoinController(IJoinRepository joinRepository)
        {
            this.joinRepository = joinRepository;
            //this.logger = logger;
        }

        [HttpPost, Route("create-candidate")]
        public async Task<IActionResult> CreateCandidate(Candidate candidate)
        {
            await this.joinRepository.Save(candidate);
            return Ok();
        }
    }
}
