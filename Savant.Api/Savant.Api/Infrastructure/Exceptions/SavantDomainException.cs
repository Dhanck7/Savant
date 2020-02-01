using System;
using System.Runtime.Serialization;

namespace Savant.Api.Infrastructure.Exceptions
{
    public class SavantDomainException : Exception
    {
        public SavantDomainException()
        {
        }

        public SavantDomainException(string message) : base(message)
        {
        }

        public SavantDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SavantDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
