using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Command.Api.Business.Features.Abstract
{
    public abstract class MovieBaseCommandAbstract
    {
        protected virtual Task<dynamic> MovieExistsMessageAsync()
        {
            try
            {
                return Task.Run<dynamic>(() => new ErrorModel { ErrorMessage = "Movie already exists", StatusCode = 401 });
            }
            catch
            {
                throw;
            }
        }
    }
}