using AutoMapper;
using Movie.Query.Api.Business.Features.Queries;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Query.Api.Mappers
{
    public sealed class GetMovieDataByTitleQueryMapperProfile : Profile
    {
        public GetMovieDataByTitleQueryMapperProfile()
        {
            base.CreateMap<GetMovieDataByTitleQuery, MovieModel>();
        }
    }
}