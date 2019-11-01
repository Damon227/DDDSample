using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class ProductionCreatedEvent : Event
    {
        public ProductionCreatedEvent(string productionId, string name, string fullName, long price)
        {
            ProductionId = productionId;
            Name = name;
            FullName = fullName;
            Price = price;
        }

        public string ProductionId { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; private set; }

        public long Price { get; private set; }
    }
}
