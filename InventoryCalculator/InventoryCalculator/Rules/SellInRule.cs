using System;

namespace InventoryCalculator.Interfaces
{
    /// <summary>
    /// SellIn/Quality rule interface
    /// rule: The Quality of an item is never negative
    /// rule: The Quality of an item is never more than 50
    /// </summary>
    public class SellInRule : ISellInRule
    {

        public virtual string Name { get; }

        protected const int QualityMin  = 0;
        protected const int QualityMax  = 50;
        protected const int SellInExpiry = 0;
        protected const int DailySellInChange = -1;

        public virtual ISellInData Apply(ISellInData item) { return null; }
    }
}
