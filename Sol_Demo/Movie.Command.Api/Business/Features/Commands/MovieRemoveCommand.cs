using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Movie.Command.Api.Business.Features.Commands
{
    [DataContract]
    public sealed class MovieRemoveCommand : IRequest<bool>
    {
        [DataMember(EmitDefaultValue = false)]
        public Guid MovieIdentity { get; set; }
    }
}