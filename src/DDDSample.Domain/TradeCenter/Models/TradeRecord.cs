using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Models;

namespace DDDSample.Domain.TradeCenter.Models
{
    public class TradeRecord : Entity
    {
        public TradeRecord(string houseId, string sellerId, string buyerId, string description = null)
        {
            if (string.IsNullOrEmpty(houseId))
            {
                throw new ArgumentNullException(nameof(houseId));
            }

            if (string.IsNullOrEmpty(sellerId))
            {
                throw new ArgumentNullException(nameof(sellerId));
            }

            if (string.IsNullOrEmpty(buyerId))
            {
                throw new ArgumentNullException(nameof(buyerId));
            }

            HouseId = houseId;
            SellerId = sellerId;
            BuyerId = buyerId;
            Description = description;
        }

        public string HouseId { get; protected set; }

        public string SellerId { get; protected set; }

        public string BuyerId { get; protected set; }

        public string Description { get; protected set; }

        public void UpdateDescription(string description)
        {
            Description = description;
        }
    }
}
