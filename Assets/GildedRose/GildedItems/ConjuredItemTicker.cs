namespace GildedRose.GildedItems
{
    public struct ConjuredItemTicker : IGildedItemTicker
    {
        public ItemData Tick(ItemData item)
        {
            item.SellIn = item.SellIn - 1;

            item.Quality = item.Quality - 2;
            if (item.SellIn < 0) item.Quality = item.Quality - 2;
            
            if (item.Quality < 0) item.Quality = 0;
            return item;
        }
    }
}