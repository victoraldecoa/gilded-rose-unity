using System;
using System.Collections.Generic;
using GildedRose.GildedItems;

namespace GildedRose
{
    public class GildedItemFactory
    {
        public IGildedItem CreateItem(string name, int quality, int sellIn)
        {
            switch (name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new Item
                    {
                        Name = name,
                        Quality = quality,
                        SellIn = sellIn
                    };
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasItem
                    {
                        Name = name,
                        Quality = quality,
                        SellIn = sellIn
                    };
                case "Aged Brie":
                    return new BrieItem
                    {
                        Name = name,
                        Quality = quality,
                        SellIn = sellIn
                    };
                default:
                    return new DefaultItem
                    {
                        Name = name,
                        Quality = quality,
                        SellIn = sellIn
                    };
            }
        }

        // use this helper method to create items by their typeof
        static IGildedItem CreateItem(Type type)
        {
            var result = Activator.CreateInstance(type) as IGildedItem;
            if (result == null) throw new Exception(string.Format("Could not instantiate item of type: {0}", type));
            return result;
        }
    }
}