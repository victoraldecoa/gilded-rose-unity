using System;
using System.Collections.Generic;

namespace GildedRose.GildedItems
{
    public class TickFunctionFactory
    {
        public Func<ItemData, ItemData> CreateTickFunction(string name)
        {
            var funcMap = new Dictionary<string, Func<ItemData, ItemData>>
            {
                {"Backstage passes to a TAFKAL80ETC concert", BackstageTick},
                {"Sulfuras, Hand of Ragnaros", SulfurasTick},
                {"Aged Brie", BrieTick},
                {"Conjured Mana Cake", ConjuredTick}
            };

            return funcMap.ContainsKey(name) ? funcMap[name] : DefaultTick;
        }

        ItemData DefaultTick(ItemData item)
        {
            item.SellIn = item.SellIn - 1;
            if (item.Quality <= 0) return item;

            item.Quality = item.Quality - 1;
            if (item.SellIn < 0) item.Quality = item.Quality - 1;

            return item;
        }

        ItemData ConjuredTick(ItemData item)
        {
            item.SellIn = item.SellIn - 1;

            item.Quality = item.Quality - 2;
            if (item.SellIn < 0) item.Quality = item.Quality - 2;

            if (item.Quality < 0) item.Quality = 0;
            return item;
        }

        ItemData BrieTick(ItemData item)
        {
            item.SellIn = item.SellIn - 1;
            if (item.Quality < 50) item.Quality = item.Quality + 1;

            if (item.SellIn < 0 && item.Quality < 50) item.Quality = item.Quality + 1;
            return item;
        }

        ItemData SulfurasTick(ItemData item)
        {
            return item;
        }

        ItemData BackstageTick(ItemData item)
        {
            item.SellIn = item.SellIn - 1;

            if (item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.SellIn < 10 && item.Quality < 50) item.Quality = item.Quality + 1;
            if (item.SellIn < 5 && item.Quality < 50) item.Quality = item.Quality + 1;

            if (item.SellIn < 0) item.Quality = 0;

            return item;
        }
    }
}