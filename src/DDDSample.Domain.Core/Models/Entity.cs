using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Infrastructure.Extensions;
using DDDSample.Infrastructure.Utilities;

namespace DDDSample.Domain.Core.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            EntityId = ID.NewSequentialGuid().ToGuidString();
            CreateTime = UpdateTime = Time.Now;
            Enable = true;
            RowVersion = ID.NewSequentialGuid().ToGuidString();
        }

        public long Id { get; protected set; }

        public string EntityId { get; protected set; }
        
        public DateTimeOffset CreateTime { get; protected set; }
        
        public DateTimeOffset UpdateTime { get; protected set; }

        public bool Enable { get; protected set; }

        public string RowVersion { get; protected set; }
    }
}
