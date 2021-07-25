using InventoryCalculator.Helpers;
using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System;

namespace InventoryCalculator.Rules
{
    public class FrozenItemRule : SellInRule
    {
        public override string Name { get; } = "Frozen Item";

        private const int WithinSellByQualityChange = -1;
        private const int ExpiredSellByQualityChange = -2;

        /// <summary>
        /// executes rule on Christmas Crackers data 
        /// rule: Frozen Item decreases in Quality by 1 
        /// rule: Once the sell by date has passed, Quality degrades twice as fast 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>updated Christmas Crackers Quality and Sellin values after rule is applied</returns>
        public override ISellInData Apply(ISellInData item)
        {
            if (item.SellIn >= SellInExpiry)
            {
                item.Quality += WithinSellByQualityChange;
            }
            else
            {
                item.Quality += ExpiredSellByQualityChange;
            }

            item.Quality = RangeSetter.Set(item.Quality, QualityMin, QualityMax);
            item.SellIn += DailySellInChange;

            return item;
        }
    }
}
