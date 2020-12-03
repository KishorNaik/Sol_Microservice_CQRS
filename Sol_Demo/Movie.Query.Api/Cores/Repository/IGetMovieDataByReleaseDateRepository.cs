using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Query.Api.Cores.Repository
{
    public interface IGetMovieDataByReleaseDateRepository
    {
        Task<IReadOnlyList<MovieModel>> GetMovieDataByReleaseDateAsync(MovieModel movieModel);
    }
}