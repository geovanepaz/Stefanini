using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDetailsDto
    {
        public int BusinessEntityID { get; set; }
        public string Name { get; set; }

        public List<PersonPhoneDto> PersonPhone;
    }
}
