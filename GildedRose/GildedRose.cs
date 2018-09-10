using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        public const int MinQuality = 0;
        public const int MaxQuality = 50;

        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured Mana Cake";

        private IList<Item> Items { get; }

        public GildedRose(IList<Item> items) =>
            Items = items;

        public void UpdateQuality()
        {
            foreach (Item item in Items)
                UpdateQuality(item);
        }

        private static void UpdateQuality(Item item)
        {
            if (item.Name == Sulfuras)
                return;

            item.SellIn = item.SellIn - 1;

            switch (item.Name)
            {
                case AgedBrie:
                    item.Quality = AgedBrieQuality(item.SellIn, item.Quality);
                    break;

                case BackstagePasses:
                    item.Quality = BackstagePassesQuality(item.SellIn, item.Quality);
                    break;

                case Conjured:
                    item.Quality = ConjuredQuality(item.SellIn, item.Quality);
                    break;

                default:
                    item.Quality = NormalQuality(item.SellIn, item.Quality);
                    break;
            }
        }

        private static int AgedBrieQuality(int sellIn, int quality)
        {
            quality += sellIn >= 0 ? 1 : 2;

            return Math.Min(quality, MaxQuality);
        }

        private static int BackstagePassesQuality(int sellIn, int quality)
        {
            if (sellIn < 0)
                return 0;

            if (sellIn < 5)
                quality += 3;
            else if (sellIn < 10)
                quality += 2;
            else
                quality += 1;

            return Math.Min(quality, MaxQuality);
        }

        private static int ConjuredQuality(int sellIn, int quality)
        {
            quality -= sellIn >= 0 ? 2 : 4;

            return Math.Max(quality, MinQuality);
        }

        private static int NormalQuality(int sellIn, int quality)
        {
            quality -= sellIn >= 0 ? 1 : 2;

            return Math.Max(quality, MinQuality);
        }
    }
}
