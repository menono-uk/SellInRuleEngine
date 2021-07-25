using InventoryCalculator.Helpers;
using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System;

namespace InventoryCalculator.Rules
{
    public class ChristmasCrackersRule : SellInRule
    {
        public override string Name { get; } = "Christmas Crackers";

        private const int MoreThan10DaysToSellBy = 1;
        private const int MoreThan5DaysToSellBy = 2;
        private const int MoreThan0DaysToSellBy = 3;

        /// <summary>
        /// executes rule on Christmas Crackers data 
        /// </summary>
        /// <param name="item"></param>
        /// <returns>updated Christmas Crackers Quality and Sellin values after rule is applied</returns>
        public override ISellInData Apply(ISellInData item)
        {
            if (item.SellIn > 10)
            {
                item.Quality += MoreThan10DaysToSellBy;
            }
            else if (item.SellIn > 5)
            {
                item.Quality += MoreThan5DaysToSellBy;
            }
            else if (item.SellIn > SellInExpiry)
            {
                item.Quality += MoreThan0DaysToSellBy;
            }
            else
            {
                item.Quality = 0;
            }

            item.Quality = RangeSetter.Set(item.Quality, QualityMin, QualityMax);
            item.SellIn += DailySellInChange;

            return item;
        }
    }
}
