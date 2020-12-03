using AutoMapper;
using Movie.Command.Api.Business.Features.Commands;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Command.Api.Mappers
{
    public sealed class MovieUpdateCommandMapperProfile : Profile
    {
        public MovieUpdateCommandMapperProfile()
        {
            base.CreateMap<MovieEditCommand, MovieModel>();
        }
    }
}