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
    public sealed class GetAllMoviesListRepository : MovieRepositoryReadAbstract, IGetAllMoviesListRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public GetAllMoviesListRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<IReadOnlyList<MovieModel>> IGetAllMoviesListRepository.GetAllMovieListAsync()
        {
            try
            {
                var dynamicParamtersTask = base.GetParameterAsync("All-Movie-Data");

                return await base.ExecuteQuery(sqlClientDbProvider, dynamicParamtersTask);
            }
            catch
            {
                throw;
            }
        }
    }
}