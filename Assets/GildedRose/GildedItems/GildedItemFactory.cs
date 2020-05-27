using System;
using System.Collections.Generic;
using GildedRose.GildedItems;

namespace GildedRose
{
    public class GildedItemFactory
    {
        static readonly Dictionary<string, Type> typeMap = new Dictionary<string, Type>
        {
            {"Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassItemTicker)},
            {"Sulfuras, Hand of Ragnaros", typeof(SulfurasItemTicker)},
            {"Aged Brie", typeof(BrieItemTicker)},
            {"Conjured Mana Cake", typeof(ConjuredItemTicker)}
        };

        public IGildedItemTicker CreateItem(string name)
        {
            var type = typeMap.ContainsKey(name) ? typeMap[name] : typeof(DefaultItemTicker);
            return CreateItem(type);
        }

        // use this helper method to create items by their typeof
        static IGildedItemTicker CreateItem(Type type)
        {
            var result = Activator.CreateInstance(type) as IGildedItemTicker;
            if (result == null) throw new Exception(string.Format("Could not instantiate item of type: {0}", type));
            return result;
        }
    }
}