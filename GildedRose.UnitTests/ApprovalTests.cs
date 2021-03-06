﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace GildedRose.UnitTests
{
    public class ApprovalTests
    {
        [Fact]
        public void ThirtyDays()
        {
            string[] lines = File.ReadAllLines("ThirtyDays.txt");

            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader($"a{Environment.NewLine}"));

            Program(new string[] { });
            string output = fakeoutput.ToString();

            string[] outputLines = output.Split(Environment.NewLine);
            for (int i = 0; i < Math.Min(lines.Length, outputLines.Length); i++)
            {
                Assert.Equal(lines[i], outputLines[i]);
            }
        }

        private static void Program(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            var app = new GildedRose(items);

            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (Item item in items)
                {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }

                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
