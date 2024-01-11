using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class EmailAlreadyExistsException : DomainException
    {
        public EmailAlreadyExistsException(string message) : base (message)
        {
        }
    }
}
