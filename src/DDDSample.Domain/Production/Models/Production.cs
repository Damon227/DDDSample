using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Models;

namespace DDDSample.Domain.Production.Models
{
    public class Production : Entity
    {
        public string Name { get; protected set; }

        public string FullName { get; protected set; }

        public long Price { get; protected set; }

        public string Desc { get; protected set; }

        public Production(string name, string fullName, long price)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                fullName = name;
            }

            Name = name;
            FullName = fullName;
            Price = price;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public void UpdateFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            FullName = fullName;
        }

        public void UpdatePrice(long price)
        {
            if (price < 0)
            {
                throw new ArgumentException("The price must be more than the 0.");
            }

            Price = price;
        }
    }
}
