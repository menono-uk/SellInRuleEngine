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
    /// <summary>
    /// Rules Engine that applies ISellInRule rules to InventoryItem collection
    /// </summary>
    public class SellInRulesEngine<TRule>
        where TRule : ISellInRule
    {
        List<TRule> _rules = new List<TRule>();

        public SellInRulesEngine(List<TRule> rules)
        {
            _rules.AddRange(rules);
        }

        /// <summary>
        /// take InventoryItems and applied relevant rules to update values
        /// </summary>
        /// <returns>updated InventoryItem after rules have been applied</returns>
        public ISellInData Calculate(ISellInData item)
        {
            ISellInData result = item;

            try
            {
                IEnumerable<TRule> itemRules = _rules.Where(x => x.Name == item.Name);

                if (itemRules.Count() > 0)
                {
                    foreach (TRule rule in itemRules)
                    {
                        result = rule.Apply(item);
                    }
                }
                else
                {
                    result.Name = "NO SUCH ITEM";
                }
            }
            catch(Exception ex)
            {
                throw new RuleEngineException(Constants.RULES_ENGINE_ERRMSG, ex.InnerException);
            }

            return result;
        }
    }
}
