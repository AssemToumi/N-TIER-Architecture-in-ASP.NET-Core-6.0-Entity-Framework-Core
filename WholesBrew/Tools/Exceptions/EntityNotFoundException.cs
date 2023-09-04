using System.Runtime.Serialization;

namespace Helper
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
