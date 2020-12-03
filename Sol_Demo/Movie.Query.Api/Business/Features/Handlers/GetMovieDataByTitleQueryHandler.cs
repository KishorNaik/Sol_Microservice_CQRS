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
    public sealed class GetMovieDataByTitleQueryHandler : MovieBaseQueryAbstract, IRequestHandler<GetMovieDataByTitleQuery, object>
    {
        private readonly IGetMovieDataByTitleRepository getMovieDataByTitleRepository = null;
        private readonly IMapper mapper = null;

        public GetMovieDataByTitleQueryHandler(IGetMovieDataByTitleRepository getMovieDataByTitleRepository, IMapper mapper)
        {
            this.getMovieDataByTitleRepository = getMovieDataByTitleRepository;
            this.mapper = mapper;
        }

        async Task<object> IRequestHandler<GetMovieDataByTitleQuery, object>.Handle(GetMovieDataByTitleQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultSet = await getMovieDataByTitleRepository?.GetMovieDataByTitleAsync(mapper.Map<MovieModel>(request));

                return (resultSet?.Count >= 1) ? (dynamic)resultSet : await base.ErrorMessageAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}