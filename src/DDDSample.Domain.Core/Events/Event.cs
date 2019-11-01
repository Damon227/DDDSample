using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Infrastructure.Utilities;
using MediatR;

namespace DDDSample.Domain.Core.Events
{
    public class Event : Message, INotification
    {
        public DateTimeOffset Timestamp { get; private set; }

        public Event()
        {
            Timestamp = Time.Now;
        }
    }
}
