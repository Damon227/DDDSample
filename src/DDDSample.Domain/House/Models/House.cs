using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Models;

namespace DDDSample.Domain.House.Models
{
    public class House : Entity
    {
        public House(string ownerId, string name, string address, float area)
        {
            if (string.IsNullOrEmpty(ownerId))
            {
                throw new ArgumentNullException(nameof(ownerId));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            OwnerId = ownerId;
            Name = name;
            TradeState = "Trading";
            Address = address;
            Area = area;
        }

        public string OwnerId { get; protected set; }

        public string Name { get; protected set; }

        public string TradeState { get; protected set; }

        public string Address { get; protected set; }

        public float Area { get; protected set; }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public void UpdateAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            Address = address;
        }

        public void UpdateArea(float area)
        {
            if (area <= 0)
            {
                throw new ArgumentException("The area must be more than the 0.");
            }

            Area = area;
        }

        public void TradeTo(string buyerId)
        {
            if (string.IsNullOrEmpty(buyerId))
            {
                throw new ArgumentNullException(nameof(buyerId));
            }

            OwnerId = buyerId;
            TradeState = "EndTrade";
        }

        public void ReTrade()
        {
            TradeState = "Trading";
        }

        public bool CanTrade()
        {
            return TradeState != "EndTrade";
        }
    }
}
