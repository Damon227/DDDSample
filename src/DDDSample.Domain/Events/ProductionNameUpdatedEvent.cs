using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class ProductionNameUpdatedEvent : Event
    {
        public ProductionNameUpdatedEvent(string productionId, string name)
        {
            ProductionId = productionId;
            Name = name;
        }

        public string ProductionId { get; private set; }

        public string Name { get; private set; }
    }
}
