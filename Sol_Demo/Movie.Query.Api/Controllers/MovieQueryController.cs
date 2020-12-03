using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Movie.Query.Api.Business.Features.Queries;

namespace Movie.Query.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieQueryController : ControllerBase
    {
        private readonly IMediator mediator = null;

        public MovieQueryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("getall")]
        public async Task<object> GetAllMovieAsync()
            => await mediator.Send(new GetAllMoviesListQuery());

        [HttpPost("searchbytitle")]
        public async Task<object> GetMovieDataByTitleAsync([FromBody] GetMovieDataByTitleQuery getMovieDataByTitleQuery)
            => await mediator.Send(getMovieDataByTitleQuery);

        [HttpPost("searchbyreleasedate")]
        public async Task<object> GetMovieDataByReleaseDateAsync([FromBody] GetMovieDataByReleaseDateQuery getMovieDataByReleaseDateQuery)
            => await mediator.Send(getMovieDataByReleaseDateQuery);
    }
}