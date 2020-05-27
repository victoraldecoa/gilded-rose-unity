using GildedRose.GildedItems;

namespace GildedRose
{
    public struct DefaultItemTicker : IGildedItemTicker
    {
        public ItemData Tick(ItemData item)
        {
            item.SellIn = item.SellIn - 1;
            if (item.Quality <= 0) return item;

            item.Quality = item.Quality - 1;
            if (item.SellIn < 0) item.Quality = item.Quality - 1;

            return item;
        }
    }
}