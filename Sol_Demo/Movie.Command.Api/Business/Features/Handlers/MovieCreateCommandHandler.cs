using AutoMapper;
using MediatR;
using Movie.Command.Api.Business.Features.Abstract;
using Movie.Command.Api.Business.Features.Commands;
using Movie.Command.Api.Cores.Repository;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movie.Command.Api.Business.Features.Handlers
{
    public sealed class MovieCreateCommandHandler : MovieBaseCommandAbstract, IRequestHandler<MovieCreateCommand, object>
    {
        private readonly IMovieCreateRepository movieCreateRepository = null;
        private readonly IMapper mapper = null;

        public MovieCreateCommandHandler(IMovieCreateRepository movieCreateRepository, IMapper mapper)
        {
            this.movieCreateRepository = movieCreateRepository;
            this.mapper = mapper;
        }

        async Task<object> IRequestHandler<MovieCreateCommand, object>.Handle(MovieCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flag = await movieCreateRepository.MoviewCreateAsync(mapper.Map<MovieModel>(request));

                return (flag == true) ? (dynamic)true : (dynamic)await base.MovieExistsMessageAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}