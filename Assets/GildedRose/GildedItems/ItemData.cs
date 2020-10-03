using System;

namespace GildedRose
{
    public struct ItemData
    {
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public Func<ItemData, ItemData> Tick;
    }
}