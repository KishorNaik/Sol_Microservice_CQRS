using Framework.SqlClient.Helper;
using Movie.Command.Api.Cores.Repository;
using Movie.Command.Api.Infrastructures.Abstract;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Framework.Models;

namespace Movie.Command.Api.Infrastructures.Repository
{
    public sealed class MovieCreateRepository : MovieRepositoryWriteAbstract, IMovieCreateRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public MovieCreateRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<bool> IMovieCreateRepository.MoviewCreateAsync(MovieModel movieModel)
        {
            try
            {
                var dynamicParameterTask = base.SetParameterAsync("Add", movieModel);

                var data = await base.ExecuteAsync(sqlClientDbProvider, dynamicParameterTask, responseContains: "Add");

                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}