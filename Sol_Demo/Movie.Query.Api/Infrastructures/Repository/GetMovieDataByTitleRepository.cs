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
    public sealed class GetMovieDataByTitleRepository : MovieRepositoryReadAbstract, IGetMovieDataByTitleRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public GetMovieDataByTitleRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<IReadOnlyList<MovieModel>> IGetMovieDataByTitleRepository.GetMovieDataByTitleAsync(MovieModel movieModel)
        {
            try
            {
                var dynamicParametersTask = base.GetParameterAsync("Movie-Title", movieModel);

                return await base.ExecuteQuery(sqlClientDbProvider, dynamicParametersTask);
            }
            catch
            {
                throw;
            }
        }
    }
}