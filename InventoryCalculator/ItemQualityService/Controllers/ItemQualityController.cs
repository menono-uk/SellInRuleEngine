using InventoryCalculator;
using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using ItemQualityService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemQualityService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemQualityController : ControllerBase
    {
        SellInCalculator _Calculator = new SellInCalculator();
        public ItemQualityController()
        {
        }

        [HttpGet]
        public InventoryItem Get()
        {
            return new InventoryItem();
        }

        [HttpPost]
        public List<StockItem> UpdateInventory(List<StockItem> items)
        {
            List<StockItem> result = null;
            try
            {
                result = Copier.Copy(_Calculator.Calculate(Copier.Copy(items)));
            }
            catch (Exception ex)
            {
                //client error response undefined - not implemented/TBD
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }

            return result;
        }
    }
}
