using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using RulesEngine.Exceptions;
using RulesEngine.HelperFunctions;
using RulesEngine.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace InventoryCalculator
{
    /// <summary>
    /// gets/sets appropriate rules for updating InventoryItem sellin/Quality values
    /// passes InventoryItems to engine to execute relevant rules
    /// </summary>
    /// <returns>updated InventoryItem collection</returns>
    public class SellInCalculator
    {
        SellInRulesEngine<ISellInRule> _RuleEngine;

        public SellInCalculator()
        {
            SellInRulesFactory factory = new SellInRulesFactory();

            factory.Get().ToList();

            _RuleEngine = new SellInRulesEngine<ISellInRule>(factory.Get().ToList());
        }

        public List<ISellInData> Calculate(List<ISellInData> items)
        {
            List<ISellInData> updateItems = new List<ISellInData>();

            if(!InventoryDataValidator.IsValid(items))
            {
                throw new InputDataException(Constants.INPUT_DATA_ERRMSG);
            }

            foreach (ISellInData item in items)
            {
                updateItems.Add(ApplyUpdateRules(item));
            }

            return updateItems;
        }

        public ISellInData Calculate(ISellInData item)
        {
            return ApplyUpdateRules(item);
        }

        ISellInData ApplyUpdateRules(ISellInData item)
        {
            return  _RuleEngine.Calculate(item);
        }
    }
}
