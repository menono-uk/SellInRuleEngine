using InventoryCalculator.Helpers;
using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System;

namespace InventoryCalculator.Rules
{
    /// <summary>
    /// Specific rule for Aged Brie product
    /// </summary>
    public class AgedBrieRule : SellInRule
    {
        public override string Name { get; } = "Aged Brie";

        private const int WithinSellByQualityChange = 1;
        private const int ExpiredSellByQualityChange = -4;

        /// <summary>
        /// executes rule on Aged Brie data 
        /// rule: Aged Brie, increases in Quality as its SellIn value approaches
        /// rule: Once the sell by date has passed, Quality degrades twice as fast 
        /// rule: Fresh Item" degrade in Quality twice as fast as “Frozen Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>updated Aged Brie Quality and Sellin values after rule is applied</returns>
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
