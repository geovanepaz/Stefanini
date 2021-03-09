using Abp.Domain.Entities;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhone
    {
        public PersonPhone(int businessEntityID, string phoneNumber, int phoneNumberTypeID)
        {
            BusinessEntityID = businessEntityID;
            PhoneNumber = phoneNumber;
            PhoneNumberTypeID = phoneNumberTypeID;
            Validate();
        }

        protected PersonPhone()
        {
        }

        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();

        public void Validate()
        {
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                throw new DomainException("O campo PhoneNumber é obrigatório");
            }

            if (BusinessEntityID < 1)
            {
                throw new DomainException("O campo BusinessEntityID é obrigatório");
            }

            if (PhoneNumberTypeID < 1)
            {
                throw new DomainException("O campo PhoneNumberTypeID é obrigatório");
            }
        }
    }
}
