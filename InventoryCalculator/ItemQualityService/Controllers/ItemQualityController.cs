using InventoryCalculator;
using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
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
        public List<ISellInData> UpdateInventory(List<ISellInData> items)
        {
            List<ISellInData> result = new List<ISellInData>();
            try
            {
                result = _Calculator.Calculate(items);
            }
            catch
            {
                //not implemented
            }

            return result;
        }
    }
}
