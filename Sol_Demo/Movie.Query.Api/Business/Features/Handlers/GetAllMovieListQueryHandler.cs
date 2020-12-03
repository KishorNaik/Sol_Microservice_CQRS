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
    public sealed class GetAllMovieListQueryHandler : MovieBaseQueryAbstract, IRequestHandler<GetAllMoviesListQuery, object>
    {
        private readonly IGetAllMoviesListRepository getAllMoviesListRepository = null;

        public GetAllMovieListQueryHandler(IGetAllMoviesListRepository getAllMoviesListRepository)
        {
            this.getAllMoviesListRepository = getAllMoviesListRepository;
        }

        async Task<object> IRequestHandler<GetAllMoviesListQuery, object>.Handle(GetAllMoviesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultSet = await getAllMoviesListRepository.GetAllMovieListAsync();

                return (resultSet?.Count >= 1) ? (dynamic)resultSet : (dynamic)await base.ErrorMessageAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}