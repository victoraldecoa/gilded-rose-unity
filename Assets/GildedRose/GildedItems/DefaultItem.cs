using GildedRose.GildedItems;

namespace GildedRose
{
    public class DefaultItem : IGildedItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void Tick()
        {
            SellIn = SellIn - 1;
            if (Quality <= 0) return;

            Quality = Quality - 1;
            if (SellIn < 0) Quality = Quality - 1;
        }
    }
}