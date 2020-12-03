using Dapper;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Framework.SqlClient.Helper;

namespace Movie.Query.Api.Infrastructures.Abstract
{
    public abstract class MovieRepositoryReadAbstract
    {
        protected virtual Task<DynamicParameters> GetParameterAsync(string command, MovieModel movieModel = null)
        {
            try
            {
                return Task.Run(() =>
                {
                    var dynamicParamters = new DynamicParameters();
                    dynamicParamters.Add("@Command", command, DbType.String, ParameterDirection.Input);
                    dynamicParamters.Add("@Title", movieModel?.Title, DbType.String, ParameterDirection.Input);
                    dynamicParamters.Add("@ReleaseStartDate", movieModel?.ReleaseStartDate, DbType.DateTime, ParameterDirection.Input);
                    dynamicParamters.Add("@ReleaseEndDate", movieModel?.ReleaseEndDate, DbType.DateTime, ParameterDirection.Input);

                    return dynamicParamters;
                });
            }
            catch
            {
                throw;
            }
        }

        protected async Task<IReadOnlyList<MovieModel>> ExecuteQuery(ISqlClientDbProvider sqlClientDbProvider, Task<DynamicParameters> dynamicParametersTask)
        {
            try
            {
                var data =
                        await
                        sqlClientDbProvider
                        ?.DapperBuilder
                        .OpenConnection(sqlClientDbProvider.GetConnection())
                        .Parameter(async () => await dynamicParametersTask)
                        .Command(async (dbConnection, dynamicParameter) =>
                        {
                            var result =
                                    await
                                        dbConnection
                                        .QueryAsync<MovieModel>(sql: "uspGetMovie", param: dynamicParameter, commandType: CommandType.StoredProcedure);

                            return result.ToList().AsReadOnly();
                        })
                        .ResultAsync<IReadOnlyList<MovieModel>>();

                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}