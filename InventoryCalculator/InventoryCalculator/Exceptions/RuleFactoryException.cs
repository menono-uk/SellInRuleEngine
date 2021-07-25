using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Exceptions
{
    /// <summary>
    /// Rule Engine related Exceptions
    /// </summary>
    public class RuleFactoryException : Exception
    {
        public RuleFactoryException(string message) : base(message)
        {
        }

        public RuleFactoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
