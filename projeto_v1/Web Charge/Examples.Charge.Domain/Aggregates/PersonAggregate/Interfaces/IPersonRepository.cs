using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository : IDisposable
    {
        Task<IEnumerable<Person>> FindAllAsync();
        Task<Person> GetByIdAsync(int id);
    }
}
