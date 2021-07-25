using InventoryCalculator.Interfaces;
using InventoryCalculator.Model;
using System.Collections.Generic;
using Xunit;

namespace InventoryCalculator
{
    public class SellInQualityCalculatorTests
    {
        private SellInCalculator _calculator = new SellInCalculator();

        [Fact]
        public void SellInCalculator_AgedBrie_IncreasedQuality()
        {
            var item = CreateInventoryItem("Aged Brie", 1, 1);
            var result = _calculator.Calculate(item);

            Assert.Equal(0, result.SellIn);
            Assert.Equal(2, result.Quality);
        }

        [Fact]
        public void SellInCalculator_ChristmasCrackers_MoreThan10Days_QualityIncreased1()
        {
            var item = CreateInventoryItem("Christmas Crackers", 11, 2);
            var result = _calculator.Calculate(item);

            Assert.Equal(10, result.SellIn);
            Assert.Equal(3, result.Quality);
        }

        [Fact]
        public void SellInCalculator_ChristmasCrackers_MoreThan5Days_QualityIncreased2()
        {
            var item = CreateInventoryItem("Christmas Crackers", 9, 2);
            var result = _calculator.Calculate(item);

            Assert.Equal(8, result.SellIn);
            Assert.Equal(4, result.Quality);
        }

        [Fact]
        public void SellInCalculator_ChristmasCrackers_LessThan6_QualityIncreased3()
        {
            var item = CreateInventoryItem("Christmas Crackers", 5, 2);
            var result = _calculator.Calculate(item);

            Assert.Equal(4, result.SellIn);
            Assert.Equal(5, result.Quality);
        }

        [Fact]
        public void SellInCalculator_ChristmasCrackers_LessThanSellBy_QualityIncreased3()
        {
            var item = CreateInventoryItem("Christmas Crackers", -1, 2);
            var result = _calculator.Calculate(item);

            Assert.Equal(-2, result.SellIn);
            Assert.Equal(0, result.Quality);
        }

        [Fact]
        public void SellInCalculator_Soap_PositiveSellIn_NoChange()
        {
            var item = CreateInventoryItem("Soap", 1, 10);
            var result = _calculator.Calculate(item);

            Assert.Equal(1, result.SellIn);
            Assert.Equal(10, result.Quality);
        }

        [Fact]
        public void SellInCalculator_Soap_NegativeSellIn_NoChange()
        {
            var item = CreateInventoryItem("Soap", -11, 10);
            var result = _calculator.Calculate(item);

            Assert.Equal(-11, result.SellIn);
            Assert.Equal(10, result.Quality);
        }

        [Fact]
        public void SellInCalculator_FrozenItemNegativeSellIn_Decreased4()
        {
            var item = CreateInventoryItem("Frozen Item", -1, 55);
            var result = _calculator.Calculate(item);

            Assert.Equal(-2, result.SellIn);
            Assert.Equal(50, result.Quality);
        }

        [Fact]
        public void SellInCalculator_FrozenItemPositiveSellIn_NoChange2()
        {
            var item = CreateInventoryItem("Frozen Item", 2, 2);
            var result = _calculator.Calculate(item);

            Assert.Equal(1, result.SellIn);
            Assert.Equal(1, result.Quality);
        }

        [Fact]
        public void SellInCalculator_InvalidName_NoSuchItem()
        {
            var item = CreateInventoryItem("INVALID ITEM", 1, 10);

            var result = _calculator.Calculate(item);

            Assert.Equal("NO SUCH ITEM", result.Name);
        }


        [Fact]
        public void SellInCalculator_FreshItemPositiveSellIn_QualityDecrease2()
        {
            var item = CreateInventoryItem("Fresh Item", 2, 2);

            var result = _calculator.Calculate(item);

            Assert.Equal(1, result.SellIn);
            Assert.Equal(0, result.Quality);
        }

        [Fact]
        public void SellInCalculator_FreshItemNegativeSellIn_QualityDecrease4()
        {
            var item = CreateInventoryItem("Fresh Item", -1, 5);

            var result = _calculator.Calculate(item);

            Assert.Equal(-2, result.SellIn);
            Assert.Equal(1, result.Quality);
        }

        [Fact]
        public void SellInCalculator_FreshItemNegativeSellIn_QualityLimitedTo0()
        {
            var item = CreateInventoryItem("Fresh Item", -1, 0);

            var result = _calculator.Calculate(item);

            Assert.Equal(-2, result.SellIn);
            Assert.Equal(0, result.Quality);
        }

        [Theory]
        [InlineData(1, .05)]
        [InlineData(2, .08)]
        [InlineData(5, .10)]
        [InlineData(10, .12)]
        [InlineData(15, .15)]
        public void ReturnsCorrectLoyaltyDiscountForLongtimeitems(int sellin, int quality)
        {
            var item = CreateInventoryItem("", sellin, quality);

            var result = _calculator.Calculate(item);
        }

        [Theory]
        [InlineData(1, .15)]
        [InlineData(2, .18)]
        [InlineData(5, .20)]
        [InlineData(10, .22)]
        [InlineData(15, .25)]
        public void ReturnsCorrectLoyaltyDiscountForLongtimeitemsOnTheirBirthday(int sellin, int quality)
        {
            var item = CreateInventoryItem("", sellin, quality);

            var result = _calculator.Calculate(item);

        }

        [Theory]
        [InlineData(1,3)]
        [InlineData(2,8)]
        public void ReturnsVeteransDiscountForLoyal1And2YearitemsOnBirthday(int sellin, int quality)
        {
            var item = CreateInventoryItem("", sellin, quality);

            var result = _calculator.Calculate(item);
        }


        private InventoryItem CreateInventoryItem(string name = "", int sellin = 0, int quality = 0)
        {
            return new InventoryItem
            {
                Name = name,
                SellIn = sellin,
                Quality = quality
            };
        }

        private List<InventoryItem> CreateInventoryitems()
        {
            List<InventoryItem> items = new List<InventoryItem>()
            {
                new InventoryItem()
                {
                    Name = "",
                    SellIn = 10,
                    Quality = 2
                },
                new InventoryItem()
                {
                    Name = "",
                    SellIn = 10,
                    Quality = 2
                },
                new InventoryItem()
                {
                    Name = "",
                    SellIn = 10,
                    Quality = 2
                },
                new InventoryItem()
                {
                    Name = "",
                    SellIn = 10,
                    Quality = 2
                },
                new InventoryItem()
                {
                    Name = "",
                    SellIn = 10,
                    Quality = 2
                },
                new InventoryItem()
                {
                    Name = "",
                    SellIn = 10,
                    Quality = 2
                }
            };

            return items;
        }
    }
}
