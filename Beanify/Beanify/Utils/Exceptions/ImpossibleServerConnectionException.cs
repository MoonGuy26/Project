using System;
namespace Beanify.Utils.Exceptions
{
    public class ImpossibleServerConnectionException:Exception
    {
        public ImpossibleServerConnectionException():base("Unable to connect to server. Please check your network connection.")
        {
            
        }

        public ImpossibleServerConnectionException(string message):base(message)
        {
            
        }

        public ImpossibleServerConnectionException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
