using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemQualityService.Model
{
    public class StockItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
