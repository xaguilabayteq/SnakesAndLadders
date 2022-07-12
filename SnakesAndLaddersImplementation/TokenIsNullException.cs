using System.Runtime.Serialization;

namespace SnakesAndLaddersImplementation
{
    [Serializable]
    public class TokenIsNullException : Exception
    {
        public TokenIsNullException()
        {
        }

        public TokenIsNullException(string? message) : base(message)
        {
        }

        public TokenIsNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TokenIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}