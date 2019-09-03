using System;
using System.Collections.Generic;
using GildedRose.GildedItems;

namespace GildedRose
{
    public class GildedItemFactory
    {
        static readonly Dictionary<string, Type> typeMap = new Dictionary<string, Type>
        {
            {"Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassItem)},
            {"Sulfuras, Hand of Ragnaros", typeof(SulfurasItem)},
            {"Aged Brie", typeof(BrieItem)}
        };

        public IGildedItem CreateItem(string name, int quality, int sellIn)
        {
            var type = typeMap.ContainsKey(name) ? typeMap[name] : typeof(DefaultItem);

            var item = CreateItem(type);
            item.Name = name;
            item.Quality = quality;
            item.SellIn = sellIn;

            return item;
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