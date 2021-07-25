using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemQualityService.Model
{
    public class Copier
    {
        public static List<ISellInData> Copy(List<StockItem> items)
        {
            List<ISellInData> copied = new List<ISellInData>();

            foreach (StockItem sitem in items)
            {

                copied.Add(
                    new InventoryItem()
                    {
                        Name = sitem.Name,
                        SellIn = sitem.SellIn,
                        Quality = sitem.Quality
                    }
                    );
            }

            return copied;
        }

        public static  List<StockItem> Copy(List<ISellInData> items)
        {
            List<StockItem> copied = new List<StockItem>();

            foreach (ISellInData sitem in items)
            {

                copied.Add(
                    new StockItem()
                    {
                        Name = sitem.Name,
                        SellIn = sitem.SellIn,
                        Quality = sitem.Quality
                    }
                    );
            }

            return copied;
        }
    }
}
