using MediatR;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Query.Api.Business.Features.Queries
{
    public sealed class GetAllMoviesListQuery : IRequest<object>
    {
    }
}