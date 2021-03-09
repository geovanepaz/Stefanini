using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper, IPersonPhoneService personPhoneService)
        {
            _personService = personService;
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonDetailsResponse> GetById(int id)
        {
            var person = await _personService.GetById(id);
            if (person == null)
            {
                return null;
            }

            var response = new PersonDetailsResponse();
            response.Person = _mapper.Map<PersonDetailsDto>(person);
            response.Person.PersonPhone = person.Phones?.Select(x => _mapper.Map<PersonPhoneDto>(x)).ToList();

            return response;
        }


        public async Task InsertPhoneAsync(PersonPhoneDto phoneDto)
        {
            var entity = _mapper.Map<PersonPhone>(phoneDto);
            await _personPhoneService.InsertPhoneAsync(entity);
        }

        public async Task UpdatePhonesAsync(List<PersonPhoneDto> phonesDto, int idPerson)
        {
            var phones = phonesDto.Select(x => new PersonPhone(idPerson, x.PhoneNumber, x.PhoneNumberTypeID)).ToList();

            await _personPhoneService.UpdatePhonesAsync(phones, idPerson);
        }

        public async Task RemovePhonesAsync(int id)
        {
            await _personPhoneService.RemovePhonesAsync(id);
        }

        public void Dispose()
        {
            _personService?.Dispose();
            _personPhoneService?.Dispose();
        }
    }
}
