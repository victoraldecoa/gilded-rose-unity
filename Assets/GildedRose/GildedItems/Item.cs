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
                case "Rice":
                    TickNormal();
                    return;
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

            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Quality > 0)
                {
                    if (Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Quality = Quality - 1;
                    }
                }
            }
            else
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (SellIn < 11)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 6)
                        {
                            if (Quality < 50)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn = SellIn - 1;
            }

            if (SellIn < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Quality > 0)
                        {
                            if (Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Quality = Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Quality = Quality - Quality;
                    }
                }
                else
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
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

        void TickNormal()
        {
            SellIn = SellIn - 1;
            if (Quality <= 0) return;

            Quality = Quality - 1;
            if (SellIn < 0) Quality = Quality - 1;
        }

        void TickBrie()
        {
            SellIn = SellIn - 1;
            if (Quality < 50) Quality = Quality + 1;

            if (SellIn < 0 && Quality < 50) Quality = Quality + 1;
        }
    }
}