using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Exceptions
{
    class HandIsNotThisTypeException : Exception
    {
        public HandIsNotThisTypeException(string message) : base(message)
        {
        }
    }
}
