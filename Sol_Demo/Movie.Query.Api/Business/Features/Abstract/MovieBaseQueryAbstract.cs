using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Query.Api.Business.Features.Abstract
{
    public abstract class MovieBaseQueryAbstract
    {
        protected virtual Task<ErrorModel> ErrorMessageAsync()
        {
            return Task.Run(() => new ErrorModel()
            {
                ErrorMessage = "No Record Found!",
                StatusCode = 204
            });
        }
    }
}