using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.Query.Api.Cores.Repository;
using Movie.Query.Api.Infrastructures.Repository;

namespace Movie.Query.Api.Configurations
{
    public static class RepositoryServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IGetAllMoviesListRepository, GetAllMoviesListRepository>();
            services.AddTransient<IGetMovieDataByReleaseDateRepository, GetMovieDataByReleaseDateRepository>();
            services.AddTransient<IGetMovieDataByTitleRepository, GetMovieDataByTitleRepository>();
        }
    }
}