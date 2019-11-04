using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.DtoModels.House
{
    public class HouseDto
    {
        public string OwnerId { get; set; }

        public string Name { get; set; }

        public string TradeState { get; set; }

        public string Address { get; set; }

        public double Area { get; set; }

        public DateTimeOffset CreateTime { get; set; }
    }
}
