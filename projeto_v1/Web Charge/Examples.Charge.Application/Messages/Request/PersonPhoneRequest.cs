using System;
using System.ComponentModel.DataAnnotations;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonPhoneRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public int BusinessEntityID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public int PhoneNumberTypeID { get; set; }
    }
}
