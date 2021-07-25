using InventoryCalculator.Interfaces;
using System;

namespace InventoryCalculator.Model
{
    /// <summary>
    /// Inventory data tyoe implementation
    /// Name: name pf item
    /// SellIn: denotes the number of days we have to sell the item 
    /// Quality: denotes how valuable the item is 
    /// </summary>
    public class InventoryItem : ISellInData
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
