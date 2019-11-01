using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Models;

namespace DDDSample.Domain.User.Models
{
    public class User : Entity
    {
        public User(string name, string phoneNumber, string idNo)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            if (string.IsNullOrEmpty(idNo))
            {
                throw new ArgumentNullException(nameof(idNo));
            }

            Name = name;
            PhoneNumber = phoneNumber;
            IDNo = idNo;
        }

        public string Name { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public string IDNo { get; protected set; }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            PhoneNumber = phoneNumber;
        }

        public void UpdateIDNo(string idNo)
        {
            if (string.IsNullOrEmpty(idNo))
            {
                throw new ArgumentNullException(nameof(idNo));
            }

            IDNo = idNo;
        }
    }
}