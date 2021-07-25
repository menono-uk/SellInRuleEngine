using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using RulesEngine.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RulesEngine.Validators
{
    internal class InventoryDataValidator
    {
        public static bool IsValid<T>(List<T> items) where T : ISellInData
        {
            if (items.Count() < 1) return false;

            return true;
        }

    }
}
