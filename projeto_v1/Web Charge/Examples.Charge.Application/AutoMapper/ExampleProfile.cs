using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;

namespace Examples.Charge.Application.AutoMapper
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<Person, PersonDto>();

            CreateMap<PersonDto, Person>()
                .ConstructUsing(c => new Person(c.BusinessEntityID, c.Name));


            CreateMap<Person, PersonDetailsDto>()
                  .ReverseMap()
                  .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.PersonPhone));

            CreateMap<PersonPhone, PersonPhoneDto>();

            CreateMap<PersonPhoneDto, PersonPhone>()
                .ConstructUsing(c => new PersonPhone(c.BusinessEntityID, c.PhoneNumber, c.PhoneNumberTypeID));

            CreateMap<PersonPhoneRequest, PersonPhoneDto>()
                .ReverseMap();

            CreateMap<PersonPhoneUpdateRequest, PersonPhoneDto>()
            .ReverseMap();

        }
    }
}
