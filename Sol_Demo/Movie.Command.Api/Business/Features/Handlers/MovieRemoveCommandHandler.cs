using AutoMapper;
using MediatR;
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
    public sealed class MovieRemoveCommandHandler : IRequestHandler<MovieRemoveCommand, bool>
    {
        private readonly IMovieRemoveRepository movieRemoveRepository = null;
        private readonly IMapper mapper = null;

        public MovieRemoveCommandHandler(IMovieRemoveRepository movieRemoveRepository, IMapper mapper)
        {
            this.movieRemoveRepository = movieRemoveRepository;
            this.mapper = mapper;
        }

        async Task<bool> IRequestHandler<MovieRemoveCommand, bool>.Handle(MovieRemoveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await movieRemoveRepository?.MovieRemoveAsync(mapper.Map<MovieModel>(request));
            }
            catch
            {
                throw;
            }
        }
    }
}