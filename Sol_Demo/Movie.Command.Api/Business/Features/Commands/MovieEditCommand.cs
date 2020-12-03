using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Command.Api.Business.Features.Commands
{
    [DataContract]
    public sealed class MovieEditCommand : IRequest<Object>
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid MovieIdentity { get; set; }

        public String Title { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}