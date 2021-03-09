using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade : IDisposable
    {
        Task<PersonResponse> FindAllAsync();
        Task<PersonDetailsResponse> GetById(int id);
        Task InsertPhoneAsync(PersonPhoneDto phoneDto);
        Task RemovePhonesAsync(int id);
        Task UpdatePhonesAsync(List<PersonPhoneDto> phonesDto, int idPerson);
    }
}