using Framework.SqlClient.Helper;
using Movie.Query.Api.Cores.Repository;
using Movie.Query.Api.Infrastructures.Abstract;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Query.Api.Infrastructures.Repository
{
    public sealed class GetMovieDataByReleaseDateRepository : MovieRepositoryReadAbstract, IGetMovieDataByReleaseDateRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public GetMovieDataByReleaseDateRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<IReadOnlyList<MovieModel>> IGetMovieDataByReleaseDateRepository.GetMovieDataByReleaseDateAsync(MovieModel movieModel)
        {
            try
            {
                var dynamicParameterTask = base.GetParameterAsync("Movie-Release-Date", movieModel);

                return await base.ExecuteQuery(sqlClientDbProvider, dynamicParameterTask);
            }
            catch
            {
                throw;
            }
        }
    }
}