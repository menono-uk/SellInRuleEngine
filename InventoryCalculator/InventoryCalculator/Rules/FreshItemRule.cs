using InventoryCalculator.Helpers;
using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System;

namespace InventoryCalculator.Rules
{
     public class FreshItemRule : SellInRule
    {
        public override string Name { get; } = "Fresh Item";

        private const int WithinSellByQualityChange = -2;
        private const int ExpiredSellByQualityChange = -4;

        /// <summary>
        /// executes rule on Christmas Crackers data 
        /// rule: Fresh Item" degrade in Quality twice as fast as “Frozen Item (“Frozen Item” decreases in Quality by 1)
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

            item.Quality = RangeSetter.Set(item.Quality, 0, 50);
            item.SellIn += DailySellInChange;

            return item;
        }
    }
}
