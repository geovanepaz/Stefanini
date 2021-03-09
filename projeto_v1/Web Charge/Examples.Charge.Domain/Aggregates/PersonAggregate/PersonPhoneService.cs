using Abp.Extensions;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository, IPersonRepository personRepository, IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _personPhoneRepository = personPhoneRepository;
            _personRepository = personRepository;
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<PersonPhone> InsertPhoneAsync(PersonPhone personPhone)
        {
            ExistPerson(personPhone.BusinessEntityID);
            ExistPhoneNumberType(personPhone.PhoneNumberTypeID);

            return await _personPhoneRepository.InsertAsync(personPhone); ;
        }

        public async Task UpdatePhonesAsync(List<PersonPhone> personPhones, int idPerson)
        {
            personPhones.ForEach(x => ExistPerson(x.BusinessEntityID));
            personPhones.ForEach(x => ExistPhoneNumberType(x.PhoneNumberTypeID));

            await RemovePhonesAsync(idPerson);
            await _personPhoneRepository.InsertRangeAsync(personPhones);
        }

        public async Task RemovePhonesAsync(int id)
        {
            var phones = GetPhones(id);
            await _personPhoneRepository.DeleteAsync(phones);

            return;
        }

        /// <summary>
        /// Busca os telefones por id e retorna exceção caso não encontre.
        /// </summary>
        /// <param name="idPerson"></param>
        /// <returns></returns>
        private List<PersonPhone> GetPhones(int idPerson)
        {
            var phones = _personPhoneRepository.GetByIdAsync(idPerson).Result;
            if (phones == null || phones.Count() == 0)
            {
                throw new NotFoundException();
            }

            return phones;
        }

        /// <summary>
        /// Valida se o Id da pessoa existe, caso não exista retorna um Exception
        /// </summary>
        /// <param name="idPerson"></param>
        private void ExistPerson(int idPerson)
        {
            if (_personRepository.GetByIdAsync(idPerson).Result == null)
            {
                throw new DomainException($"Não foi encontrada uma pessoa relacionada ao id: {idPerson}");
            }
        }

        /// <summary>
        /// Valida se o Tipo de telefone existe, caso não exista retorna um Exception
        /// </summary>
        /// <param name="id"></param>
        private void ExistPhoneNumberType(int id)
        {
            if (_phoneNumberTypeRepository.GetByIdAsync(id).Result == null)
            {
                throw new DomainException($"Não foi encontrado um tipo de telefone relacionado ao id:{id} ");
            }
        }

        public void Dispose()
        {
            _personPhoneRepository?.Dispose();
            _personRepository?.Dispose();
            _phoneNumberTypeRepository?.Dispose();
        }
    }
}
