using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository : IDisposable
    {
        Task<IEnumerable<PersonPhone>> FindAllAsync();
        Task<PersonPhone> InsertAsync(PersonPhone phone);
        Task<List<PersonPhone>> GetByIdAsync(int id);
        Task DeleteAsync(List<PersonPhone> phones);
        Task InsertRangeAsync(List<PersonPhone> phones);
    }
}
