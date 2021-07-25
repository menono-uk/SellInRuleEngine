using System;
using System.Collections.Generic;

namespace InventoryCalculator.Interfaces
{
    /// <summary>
    /// Factory for creating/retrieving rule sets
    /// </summary>
    public interface ISellInRuleFactory
    {
        public IEnumerable<ISellInRule> Get();
    }
}
