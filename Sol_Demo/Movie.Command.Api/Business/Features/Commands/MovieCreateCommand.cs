using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Command.Api.Business.Features.Commands
{
    [DataContract]
    public sealed class MovieCreateCommand : IRequest<object>
    {
        [DataMember(EmitDefaultValue = false)]
        public String Title { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? ReleaseDate { get; set; }
    }
}