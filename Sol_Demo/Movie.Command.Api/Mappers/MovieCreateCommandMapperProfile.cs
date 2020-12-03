using AutoMapper;
using Movie.Command.Api.Business.Features.Commands;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Command.Api.Mappers
{
    public class MovieCreateCommandMapperProfile : Profile
    {
        public MovieCreateCommandMapperProfile()
        {
            base.CreateMap<MovieCreateCommand, MovieModel>();
        }
    }
}