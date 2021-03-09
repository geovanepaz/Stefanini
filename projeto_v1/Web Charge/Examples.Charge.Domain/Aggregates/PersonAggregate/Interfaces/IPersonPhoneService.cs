using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService : IDisposable
    {
        Task<PersonPhone> InsertPhoneAsync(PersonPhone personPhone);
        Task<List<PersonPhone>> FindAllAsync();
        Task RemovePhonesAsync(int id);
        Task UpdatePhonesAsync(List<PersonPhone> personPhones, int idPerson);
    }
}
