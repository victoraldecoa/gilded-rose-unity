namespace GildedRose.GildedItems
{
    public class ConjuredItem : DefaultItem
    {
        public override void Tick()
        {
            SellIn = SellIn - 1;

            Quality = Quality - 2;
            if (SellIn < 0) Quality = Quality - 2;
            
            if (Quality < 0) Quality = 0;
        }
    }
}