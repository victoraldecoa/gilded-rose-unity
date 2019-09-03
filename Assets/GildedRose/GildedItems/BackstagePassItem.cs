namespace GildedRose
{
    class BackstagePassItem : DefaultItem
    {
        public override void Tick()
        {
            SellIn = SellIn - 1;

            if (Quality < 50) Quality = Quality + 1;
            if (SellIn < 10 && Quality < 50) Quality = Quality + 1;
            if (SellIn < 5 && Quality < 50) Quality = Quality + 1;
            
            if (SellIn < 0) Quality = 0;
        }
    }
}