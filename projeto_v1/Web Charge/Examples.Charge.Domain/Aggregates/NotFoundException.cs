using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Domain.Aggregates
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        { }

        public NotFoundException(string message) : base(message)
        { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
