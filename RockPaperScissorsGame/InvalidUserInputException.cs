using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException()
        {
        }

        public InvalidUserInputException(string? message) : base(message)
        {
        }

        public InvalidUserInputException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidUserInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
