using System.Runtime.Serialization;

namespace Archable.Application.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
            :base("Not Found: ENTITY exception.") { }

        public EntityNotFoundException(string message)
            : base(message) { }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner) { }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}