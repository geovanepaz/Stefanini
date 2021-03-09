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
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);


        public async Task<PersonPhone> InsertAsync(PersonPhone phone)
        {
            await _context.AddAsync(phone);
            await _context.SaveChangesAsync();

            return phone;
        }

        public async Task InsertRangeAsync(List<PersonPhone> phones)
        {
            await _context.AddRangeAsync(phones);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PersonPhone>> GetByIdAsync(int id)
        {
            return await _context.PersonPhone
                                    .AsNoTracking()
                                    .AsQueryable()
                                    .Where(x => x.BusinessEntityID == id)
                                    .ToListAsync();
        }

        public async Task DeleteAsync(List<PersonPhone> phones)
        {
            _context.RemoveRange(phones);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
