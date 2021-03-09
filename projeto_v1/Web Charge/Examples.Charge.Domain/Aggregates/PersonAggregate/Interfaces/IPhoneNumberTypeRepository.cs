using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeRepository : IDisposable
    {
        Task<IEnumerable<PersonAggregate.PhoneNumberType>> FindAllAsync();

        Task<PhoneNumberType> GetByIdAsync(int id);
    }
}
