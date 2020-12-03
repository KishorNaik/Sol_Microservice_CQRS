using Framework.SqlClient.Helper;
using Movie.Command.Api.Cores.Repository;
using Movie.Command.Api.Infrastructures.Abstract;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Command.Api.Infrastructures.Repository
{
    public sealed class MovieEditRepository : MovieRepositoryWriteAbstract, IMovieEditRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public MovieEditRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<bool> IMovieEditRepository.MovieEditAsync(MovieModel movieModel)
        {
            try
            {
                var dynamicParameterTask = base.SetParameterAsync("Update", movieModel);

                var data = await base.ExecuteAsync(sqlClientDbProvider, dynamicParameterTask, responseContains: "Update");

                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}