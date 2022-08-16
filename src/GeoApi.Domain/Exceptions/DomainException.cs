using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GeoApi.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception ex) : base(message, ex)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
