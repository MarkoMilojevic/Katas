using System.Collections.Generic;
using Xunit;

namespace GildedRose.UnitTests
{
    public class GildedRoseTests
    {
        [Fact]
        public void EndOfDayLowersItemsQualityAndSellIn()
        {
            const int quality = 10;
            const int sellIn = 10;

            var items = new List<Item> { new Item { Name = "Item", SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality - 1, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Fact]
        public void QualityDegradesTwiceAsFastWhenSellDatePasses()
        {
            const int quality = 10;
            const int sellIn = 0;

            var items = new List<Item> { new Item { Name = "Item", SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality - 2, items[0].Quality);
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            const int quality = 0;
            const int sellIn = 0;

            var items = new List<Item> { new Item { Name = "Item", SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality, items[0].Quality);
        }

        [Fact]
        public void AgedBrieIncreasesInQualityTheOlderItGets()
        {
            const int quality = 10;
            const int sellIn = 10;

            var items = new List<Item> { new Item { Name = GildedRose.AgedBrie, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality + 1, items[0].Quality);
        }

        [Fact]
        public void AgedBrieIncreasesInQualityTwiceAsFastWhenSellDatePasses()
        {
            const int quality = 10;
            const int sellIn = 0;

            var items = new List<Item> { new Item { Name = GildedRose.AgedBrie, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality + 2, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncreasesInQualityTheOlderItGets()
        {
            const int quality = 10;
            const int sellIn = 20;

            var items = new List<Item> { new Item { Name = GildedRose.BackstagePasses, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality + 1, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncreasesInQualityTwiceAsFastTenDaysBeforeSellDate()
        {
            const int quality = 10;
            const int sellIn = 10;

            var items = new List<Item> { new Item { Name = GildedRose.BackstagePasses, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality + 2, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesIncreasesInQualityThreeTimesAsFastFiveDaysBeforeSellDate()
        {
            const int quality = 10;
            const int sellIn = 5;

            var items = new List<Item> { new Item { Name = GildedRose.BackstagePasses, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality + 3, items[0].Quality);
        }

        [Fact]
        public void BackstagePassesQualityDropsToZeroWhenSellDatePasses()
        {
            const int quality = 10;
            const int sellIn = 0;

            var items = new List<Item> { new Item { Name = GildedRose.BackstagePasses, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void SulfurasNeverHasToBeSoldAndDoesntLoseQualityAsTimePasses()
        {
            const int quality = 80;
            const int sellIn = 10;

            var items = new List<Item> { new Item { Name = GildedRose.Sulfuras, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality, items[0].Quality);
            Assert.Equal(sellIn, items[0].SellIn);
        }

        [Theory]
        [InlineData(GildedRose.AgedBrie, 10)]
        [InlineData(GildedRose.AgedBrie, 0)]
        [InlineData(GildedRose.BackstagePasses, 20)]
        [InlineData(GildedRose.BackstagePasses, 10)]
        [InlineData(GildedRose.BackstagePasses, 5)]
        public void ItemCannotHaveHigherQualityThanFiftyUnlessSulfuras(string itemName, int sellIn)
        {
            const int maxQuality = 50;

            var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = maxQuality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(maxQuality, items[0].Quality);
        }
    }
}
