
using System.Runtime.Serialization;

namespace Helper
{
    [Serializable]
    public class InvalidAttributeUsageException : Exception
    {
        public InvalidAttributeUsageException()
        {
        }

        public InvalidAttributeUsageException(string message)
            : base(message)
        {
        }

        public InvalidAttributeUsageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidAttributeUsageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
