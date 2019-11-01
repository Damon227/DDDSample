using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DDDSample.Domain.Events;
using MediatR;

namespace DDDSample.Domain.EventHandlers
{
    public class ProductionEventHandler : 
        INotificationHandler<ProductionCreatedEvent>, 
        INotificationHandler<ProductionNameUpdatedEvent>
    {
        public Task Handle(ProductionCreatedEvent notification, CancellationToken cancellationToken)
        {
            // do something

            return Task.CompletedTask;
        }

        public Task Handle(ProductionNameUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // do something

            return Task.CompletedTask;
        }
    }
}
