using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Infrastructure.Utilities;
using MediatR;

namespace DDDSample.Domain.Core.Events
{
    public class Command : Message
    {
        public DateTimeOffset Timestamp { get; private set; }

        public Command()
        {
            Timestamp = Time.Now;
        }
    }

    public class Command<TResponse> : IRequest<TResponse>
    {
        public DateTimeOffset Timestamp { get; private set; }

        public Command()
        {
            Timestamp = Time.Now;
        }
    }
}
