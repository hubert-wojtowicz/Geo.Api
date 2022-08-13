using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GeoApi.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class DomainArgumentException : DomainException, ISerializable
    {
        public DomainArgumentException(string message, string name) : base(message)
        {
            Name = name;
        }

        public DomainArgumentException(string message, string name, Exception ex) : base(message, ex)
        {
            Name = name;
        }

        protected DomainArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Name = info.GetString($"{nameof(DomainException)}.{nameof(Name)}");
        }

        public string Name { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue($"{nameof(DomainException)}.{nameof(Name)}", Name);
        }
    }
}

