using System.Runtime.Serialization;

namespace SnakesAndLaddersImplementation
{
    [Serializable]
    public class CurrentPlayerDoesntExistException : Exception
    {
        public CurrentPlayerDoesntExistException()
        {
        }

        public CurrentPlayerDoesntExistException(string? message) : base(message)
        {
        }

        public CurrentPlayerDoesntExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CurrentPlayerDoesntExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}