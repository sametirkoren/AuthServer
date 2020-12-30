using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base()
        {

        }

        public CustomException(string message) : base(message)
        {

        }
        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
