using Microsoft.Extensions.DependencyInjection;
using Movie.Command.Api.Cores.Repository;
using Movie.Command.Api.Infrastructures.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Command.Api.Configurations
{
    public static class RepositoryServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMovieCreateRepository, MovieCreateRepository>();
            services.AddTransient<IMovieEditRepository, MovieEditRepository>();
            services.AddTransient<IMovieRemoveRepository, MovieRemoveRepository>();
        }
    }
}