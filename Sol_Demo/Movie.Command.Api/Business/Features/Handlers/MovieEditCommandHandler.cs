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
    public sealed class MovieEditCommandHandler : MovieBaseCommandAbstract, IRequestHandler<MovieEditCommand, Object>
    {
        private readonly IMovieEditRepository movieEditRepository = null;
        private readonly IMapper mapper = null;

        public MovieEditCommandHandler(IMovieEditRepository movieEditRepository, IMapper mapper)
        {
            this.movieEditRepository = movieEditRepository;
            this.mapper = mapper;
        }

        async Task<object> IRequestHandler<MovieEditCommand, object>.Handle(MovieEditCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flag = await movieEditRepository.MovieEditAsync(mapper.Map<MovieModel>(request));

                return (flag == true) ? (dynamic)true : (dynamic)await base.MovieExistsMessageAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}