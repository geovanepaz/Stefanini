using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);
        public async Task<Person> GetByIdAsync(int id)
        {
            var response = await _context.Person
                                    .AsNoTracking()
                                    .Include(x => x.Phones)
                                    .FirstOrDefaultAsync(x => x.BusinessEntityID == id);
            return response;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
