using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Query.Api.Cores.Repository
{
    public interface IGetAllMoviesListRepository
    {
        Task<IReadOnlyList<MovieModel>> GetAllMovieListAsync();
    }
}