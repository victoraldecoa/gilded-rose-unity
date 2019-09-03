namespace GildedRose.GildedItems
{
    public interface IGildedItem
    {
        string Name { get; set; }
        int Quality { get; set; }
        int SellIn { get; set; }
        
        void Tick();
    }
}