using System;

namespace InventoryCalculator.Interfaces
{
    /// <summary>
    /// inventory data for sellin/quality calculations
    /// </summary>
    public interface ISellInData : IData
    {
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
