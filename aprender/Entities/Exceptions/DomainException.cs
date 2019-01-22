using System;

namespace aprender.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message)
            :base(message)
        {

        }
    }
}
