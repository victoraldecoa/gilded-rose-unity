using GildedRose.GildedItems;
using UnityEngine.UI;

namespace GildedRose
{
    public class Item : IGildedItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void Tick()
        {
            switch (Name)
            {
                case "Aged Brie":
                    TickBrie();
                    return;
                case "Sulfuras, Hand of Ragnaros":
                    TickSulfuras();
                    return;
                case "Backstage passes to a TAFKAL80ETC concert":
                    TickBackstage();
                    return;
            }
        }

        void TickBackstage()
        {
            SellIn = SellIn - 1;

            if (Quality < 50) Quality = Quality + 1;
            if (SellIn < 10 && Quality < 50) Quality = Quality + 1;
            if (SellIn < 5 && Quality < 50) Quality = Quality + 1;
            
            if (SellIn < 0) Quality = 0;
        }

        void TickSulfuras()
        {
        }

        void TickBrie()
        {
            SellIn = SellIn - 1;
            if (Quality < 50) Quality = Quality + 1;

            if (SellIn < 0 && Quality < 50) Quality = Quality + 1;
        }
    }
}