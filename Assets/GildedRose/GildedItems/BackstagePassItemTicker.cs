using GildedRose.GildedItems;

namespace GildedRose
{
    public struct BackstagePassItemTicker : IGildedItemTicker
    {
        public ItemData Tick(ItemData item)
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