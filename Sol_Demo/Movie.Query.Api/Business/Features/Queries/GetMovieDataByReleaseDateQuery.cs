using MediatR;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Query.Api.Business.Features.Queries
{
    [DataContract]
    public sealed class GetMovieDataByReleaseDateQuery : IRequest<object>
    {
        [DataMember(EmitDefaultValue = false)]
        public DateTime? ReleaseStartDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? ReleaseEndDate { get; set; }
    }
}