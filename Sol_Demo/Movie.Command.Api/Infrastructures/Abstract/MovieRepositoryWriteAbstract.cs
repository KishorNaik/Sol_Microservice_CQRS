using Dapper;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Framework.SqlClient.Helper;
using Framework.Models;

namespace Movie.Command.Api.Infrastructures.Abstract
{
    public abstract class MovieRepositoryWriteAbstract
    {
        protected virtual Task<DynamicParameters> SetParameterAsync(String command, MovieModel movieModel)
        {
            return Task.Run(() =>
            {
                var dynamicParameter = new DynamicParameters();

                dynamicParameter.Add("@Command", command, DbType.String, ParameterDirection.Input);
                dynamicParameter.Add("@MovieIdentity", movieModel.MovieIdentity, DbType.Guid, ParameterDirection.Input);
                dynamicParameter.Add("@Title", movieModel.Title, direction: ParameterDirection.Input);
                dynamicParameter.Add("@ReleaseDate", movieModel.ReleaseDate, DbType.DateTime, ParameterDirection.Input);
                dynamicParameter.Add("@IsDelete", movieModel.IsDelete, DbType.Boolean, ParameterDirection.Input);

                return dynamicParameter;
            });
        }

        protected async Task<bool> ExecuteAsync(ISqlClientDbProvider sqlClientDbProvider, Task<DynamicParameters> taskDynamicParameters, String responseContains)
        {
            try
            {
                return
                    await
                    sqlClientDbProvider
                        .DapperBuilder
                        .OpenConnection(sqlClientDbProvider.GetConnection())
                        .Parameter(async () => await taskDynamicParameters)
                        .Command(async (dbConnection, dynamicParameter) =>
                        {
                            var data =
                                    (await
                                    dbConnection
                                    ?.QueryAsync<MessageModel>(sql: "uspSetMovie", param: dynamicParameter, commandType: CommandType.StoredProcedure))
                                    ?.FirstOrDefault()
                                    ?.Message;

                            return (data.Contains(responseContains) ? true : false);
                        })
                        .ResultAsync<Boolean>();
            }
            catch
            {
                throw;
            }
        }
    }
}