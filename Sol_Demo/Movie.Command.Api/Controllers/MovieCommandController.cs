using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Command.Api.Business.Features.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Command.Api.Controllers
{
    // Using Open Api Standard : do not use IActionResult, If you are consumeing api on client side using OPEN Api standard.
    // If you want JSON object then use IActionResult

    [Produces("application/json")]
    [Route("api/moviecommand")]
    [ApiController]
    public class MovieCommandController : ControllerBase
    {
        private readonly IMediator mediator = null;

        public MovieCommandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<Object> OnMovieCreateAsync([FromBody] MovieCreateCommand movieCreateCommand)
            => await mediator.Send<Object>(movieCreateCommand);

        [HttpPost("edit")]
        public async Task<Object> OnMovieEditAsync([FromBody] MovieEditCommand movieEditCommand)
            => await mediator.Send<Object>(movieEditCommand);

        [HttpPost("remove")]
        public async Task<bool> OnMovieRemoveAsync([FromBody] MovieRemoveCommand movieRemoveCommand)
            => await mediator.Send<bool>(movieRemoveCommand);
    }
}