using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Exceptions
{
    /// <summary>
    /// Rule related Exceptions
    /// </summary>
    public class InputDataException : Exception
    {
        public InputDataException(string message) : base(message)
        {
        }

        public InputDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
