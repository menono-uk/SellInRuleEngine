using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Exceptions
{
    /// <summary>
    /// Rule Engine related Exceptions
    /// </summary>
    public class RuleEngineException : Exception
    {
        public RuleEngineException(string message) : base(message)
        {
        }

        public RuleEngineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
