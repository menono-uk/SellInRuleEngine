using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using RulesEngine.Exceptions;
using RulesEngine.HelperFunctions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace InventoryCalculator
{
    public class SellInRulesFactory
    {

        /// <summary>
        /// uses reflection to retrieve ISellInRules set used in Rules Engine
        /// </summary>
        /// <returns>returns ISellInRules collection</returns>
        public IEnumerable<ISellInRule> Get()
        {
            try
            {
                var ruleType = typeof(ISellInRule);

                IEnumerable<ISellInRule> rules = this.GetType().Assembly.GetTypes()
                    .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
                    .Select(r => Activator.CreateInstance(r) as ISellInRule);

                return rules;
            }
            catch(Exception ex)
            {
                throw new RuleFactoryException(Constants.RULES_FACTORY_ERRMSG, ex.InnerException);
            }
        }

    }
}
