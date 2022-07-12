using System.Runtime.Serialization;

namespace SnakesAndLaddersImplementation
{
    [Serializable]
    public class PlayerAlreadyExistException : Exception
    {
        public PlayerAlreadyExistException()
        {
        }

        public PlayerAlreadyExistException(string? message) : base(message)
        {
        }

        public PlayerAlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlayerAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
