using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class HouseTradedEvent : Event
    {
        public HouseTradedEvent(string houseId, string buyerId)
        {
            HouseId = houseId;
            BuyerId = buyerId;
        }

        public string HouseId { get; private set; }

        public string BuyerId { get; private set; }
    }
}
