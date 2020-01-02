using System;
using System.Runtime.Serialization;

namespace Poker.GameTypes
{
    [Serializable]
    internal class HandWrongSizeException : Exception
    {
        public HandWrongSizeException()
        {
        }

        public HandWrongSizeException(string message) : base(message)
        {
        }

        public HandWrongSizeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HandWrongSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}