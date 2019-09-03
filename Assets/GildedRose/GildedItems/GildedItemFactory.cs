using System;
using System.Collections.Generic;
using GildedRose.GildedItems;

namespace GildedRose
{
    public class GildedItemFactory
    {
        public IGildedItem CreateItem(string name, int quality, int sellIn)
        {
            return new Item
            {
                Name = name,
                Quality = quality,
                SellIn = sellIn
            };
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