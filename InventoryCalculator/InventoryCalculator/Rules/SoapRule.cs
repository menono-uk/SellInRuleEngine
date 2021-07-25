using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System;

namespace InventoryCalculator.Rules
{
    public class SoapRule : SellInRule
    {
        public override string Name { get; } = "Soap";

        /// <summary>
        /// uses reflection to retrieve ISellInRules set used in Rules Engine
        /// rule: never has to be sold or decreases in Quality
        /// </summary>
        /// <returns>returns ISellInRules collection</returns>
        public override ISellInData Apply(ISellInData item)
        {
            return item;
        }
    }
}
