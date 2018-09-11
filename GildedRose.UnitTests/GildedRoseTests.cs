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

            var items = new List<Item> { new Item { Name = "Normal item", SellIn = sellIn, Quality = quality } };

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

            var items = new List<Item> { new Item { Name = "Normal item", SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality - 2, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            const int quality = GildedRose.MinQuality;
            const int sellIn = 0;

            var items = new List<Item> { new Item { Name = "Normal item", SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(quality, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Fact]
        public void BackstagePassesQualityDropsToZeroWhenSellDatePasses()
        {
            const int quality = 10;
            const int sellIn = 0;

            var items = new List<Item> { new Item { Name = GildedRose.BackstagePasses, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(GildedRose.MinQuality, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
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
            var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = GildedRose.MaxQuality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(GildedRose.MaxQuality, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }

        [Theory]
        [InlineData(10, 10, 8)]
        [InlineData(10, 0, 6)]
        public void ConjuredQualityDegradesTwiceAsFastAsNormalItems(int quality, int sellIn, int expectedQuality)
        {
            var items = new List<Item> { new Item { Name = GildedRose.Conjured, SellIn = sellIn, Quality = quality } };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.Equal(expectedQuality, items[0].Quality);
            Assert.Equal(sellIn - 1, items[0].SellIn);
        }
    }
}
