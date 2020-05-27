using GildedRose.GildedItems;

namespace GildedRose
{
    public struct SulfurasItemTicker : IGildedItemTicker
    {
        public ItemData Tick(ItemData item)
        {
            return item;
        }
    }
}