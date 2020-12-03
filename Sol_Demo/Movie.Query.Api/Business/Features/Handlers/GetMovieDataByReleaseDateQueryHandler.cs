using AutoMapper;
using MediatR;
using Movie.Query.Api.Business.Features.Abstract;
using Movie.Query.Api.Business.Features.Queries;
using Movie.Query.Api.Cores.Repository;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movie.Query.Api.Business.Features.Handlers
{
    public sealed class GetMovieDataByReleaseDateQueryHandler : MovieBaseQueryAbstract, IRequestHandler<GetMovieDataByReleaseDateQuery, object>
    {
        private readonly IGetMovieDataByReleaseDateRepository getMovieDataByReleaseDateRepository = null;
        private readonly IMapper mapper = null;

        public GetMovieDataByReleaseDateQueryHandler(IGetMovieDataByReleaseDateRepository getMovieDataByReleaseDateRepository, IMapper mapper)
        {
            this.getMovieDataByReleaseDateRepository = getMovieDataByReleaseDateRepository;
            this.mapper = mapper;
        }

        async Task<object> IRequestHandler<GetMovieDataByReleaseDateQuery, object>.Handle(GetMovieDataByReleaseDateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultSet = await getMovieDataByReleaseDateRepository?.GetMovieDataByReleaseDateAsync(mapper.Map<MovieModel>(request));

                return (resultSet?.Count >= 1) ? (dynamic)resultSet : (dynamic)await base.ErrorMessageAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}