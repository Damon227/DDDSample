using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Application.DtoModels.Production
{
    public class ProductionDto
    {
        public string EntityId { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public long Price { get; set; }

        public DateTimeOffset CreateTime { get; set; }
    }
}
