using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Utils.Exceptions
{
    public class UnsuccessfulStatusCodeException : Exception
    {
        public UnsuccessfulStatusCodeException()
        {
        }

        public UnsuccessfulStatusCodeException(string message) : base(message)
        {
        }

        public UnsuccessfulStatusCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
