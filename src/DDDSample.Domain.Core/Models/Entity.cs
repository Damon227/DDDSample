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
            Id = ID.NewSequentialGuid().ToGuidString();
            CreateTime = UpdateTime = Time.Now;
            Enable = true;
            ConcurrencyToken = ID.NewSequentialGuid().ToGuidString();
        }

        public string Id { get; protected set; }
        
        public DateTimeOffset CreateTime { get; protected set; }
        
        public DateTimeOffset UpdateTime { get; protected set; }

        public bool Enable { get; protected set; }

        public string ConcurrencyToken { get; protected set; }

        public override bool Equals(object obj)
        {
            Entity compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
