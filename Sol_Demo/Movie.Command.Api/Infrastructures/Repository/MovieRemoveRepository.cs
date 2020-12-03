using Framework.SqlClient.Helper;
using Movie.Command.Api.Cores.Repository;
using Movie.Command.Api.Infrastructures.Abstract;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Movie.Command.Api.Infrastructures.Repository
{
    public sealed class MovieRemoveRepository : MovieRepositoryWriteAbstract, IMovieRemoveRepository
    {
        private readonly ISqlClientDbProvider sqlClientDbProvider = null;

        public MovieRemoveRepository(ISqlClientDbProvider sqlClientDbProvider)
        {
            this.sqlClientDbProvider = sqlClientDbProvider;
        }

        async Task<bool> IMovieRemoveRepository.MovieRemoveAsync(MovieModel movieModel)
        {
            try
            {
                var dynamicParameterTask = base.SetParameterAsync("Delete", movieModel);

                var data =
                        await
                            sqlClientDbProvider
                            .DapperBuilder
                            .OpenConnection(sqlClientDbProvider.GetConnection())
                            .Parameter(async () => await dynamicParameterTask)
                            .Command(async (dbConnection, dynamicParameter) =>
                            {
                                var result =
                                        await
                                            dbConnection
                                            .ExecuteAsync(sql: "uspSetMovie", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                                return (result == 1) ? true : false;
                            })
                            .ResultAsync<bool>();

                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}