using GildedRose;
using GildedRose.GildedItems;
using NUnit.Framework;

namespace Editor.Tests
{
	public class GildedRoseTest
	{
		class TestSubject
		{
			public int SellIn { get; set; }
			public int Quality { get; set; }

			public IGildedItemTicker Ticker;

			public void Tick()
			{
				var result = Ticker.Tick(new ItemData {SellIn = SellIn, Quality = Quality});
				SellIn = result.SellIn;
				Quality = result.Quality;
			}
		}
		
		readonly GildedItemFactory _itemFactory = new GildedItemFactory();
		TestSubject CreateItem(string name, int quality, int sellIn)
		{
			return new TestSubject
			{
				Ticker = _itemFactory.CreateItem(name),
				Quality = quality,
				SellIn = sellIn
			};
		}

		// normal item
		
		[Test]
		public void TestNormalItemBeforeSellDate()
		{
			var item = CreateItem("Rice", 10, 2);
			item.Tick();
			Assert.AreEqual(9, item.Quality);
			Assert.AreEqual(1, item.SellIn);
		}
	
		[Test]
		public void TestNormalItemOnSellDate()
		{
			var item = CreateItem("Rice", 10, 0);
			item.Tick();
			Assert.AreEqual(8, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
	
		[Test]
		public void TestNormalItemAfterSellDate()
		{
			var item = CreateItem("Rice", 10, -5);
			item.Tick();
			Assert.AreEqual(8, item.Quality);
			Assert.AreEqual(-6, item.SellIn);
		}
	
		[Test]
		public void TestNormalItemAtZeroQuality()
		{
			var item = CreateItem("Rice", 0, 5);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(4, item.SellIn);
		}
		
		// brie item
		
		[Test]
		public void TestBrieBeforeSellDate()
		{
			var item = CreateItem("Aged Brie", 10, 2);
			item.Tick();
			Assert.AreEqual(11, item.Quality);
			Assert.AreEqual(1, item.SellIn);
		}
	
		[Test]
		public void TestBrieBeforeSellDateWithMaxQuality()
		{
			var item = CreateItem("Aged Brie", 50, 2);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(1, item.SellIn);
		}
	
		[Test]
		public void TestBrieOnSellDate()
		{
			var item = CreateItem("Aged Brie", 10, 0);
			item.Tick();
			Assert.AreEqual(12, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
	
		[Test]
		public void TestBrieOnSellDateNearMaxQuality()
		{
			var item = CreateItem("Aged Brie", 49, 0);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
		
		[Test]
		public void TestBrieOnSellDateWithMaxQuality()
		{
			var item = CreateItem("Aged Brie", 50, 0);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
		
		// sulfuras item

		[Test]
		public void TestSulfurasBeforeSellDate()
		{
			var item = CreateItem("Sulfuras, Hand of Ragnaros", 80, 2);
			item.Tick();
			Assert.AreEqual(80, item.Quality);
			Assert.AreEqual(2, item.SellIn);
		}
	
		[Test]
		public void TestSulfurasOnSellDate()
		{
			var item = CreateItem("Sulfuras, Hand of Ragnaros", 80, 0);
			item.Tick();
			Assert.AreEqual(80, item.Quality);
			Assert.AreEqual(0, item.SellIn);
		}
		
		// backstage pass item
		
		[Test]
		public void TestBackstagePassLongBeforeSellDate()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, 11);
			item.Tick();
			Assert.AreEqual(31, item.Quality);
			Assert.AreEqual(10, item.SellIn);
		}
		
		[Test]
		public void TestBackstageMediumCloseToSellDateUpperBound()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 20, 10);
			item.Tick();
			Assert.AreEqual(22, item.Quality);
			Assert.AreEqual(9, item.SellIn);
		}
		
		[Test]
		public void TestBackstageMediumCloseToSellDateUpperBoundAtMaxQuality()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 50, 10);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(9, item.SellIn);
		}
		
		[Test]
		public void TestBackstageMediumCloseToSellDateLowerBound()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, 6);
			item.Tick();
			Assert.AreEqual(32, item.Quality);
			Assert.AreEqual(5, item.SellIn);
		}
		
		[Test]
		public void TestBackstageMediumCloseToSellDateLowerBoundAtMaxQuality()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 50, 6);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(5, item.SellIn);
		}
		
		[Test]
		public void TestBackstageVeryCloseToSellDateUpperBound()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, 5);
			item.Tick();
			Assert.AreEqual(33, item.Quality);
			Assert.AreEqual(4, item.SellIn);
		}
		
		[Test]
		public void TestBackstageVeryCloseToSellDateUpperBoundAtAlmostMaxQuality()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 49, 5);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(4, item.SellIn);
		}
		
		[Test]
		public void TestBackstageVeryCloseToSellDateLowerBound()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, 1);
			item.Tick();
			Assert.AreEqual(33, item.Quality);
			Assert.AreEqual(0, item.SellIn);
		}
		
		[Test]
		public void TestBackstageVeryCloseToSellDateLowerBoundAtMaxQuality()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 50, 1);
			item.Tick();
			Assert.AreEqual(50, item.Quality);
			Assert.AreEqual(0, item.SellIn);
		}
		
		[Test]
		public void TestBackstageOnSellDate()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, 0);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
		
		[Test]
		public void TestBackstageAfterSellDate()
		{
			var item = CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, -2);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(-3, item.SellIn);
		}
		
		// conjured item
	
		[Test]
		public void TestConjuredItemBeforeSellDate()
		{
			var item = CreateItem("Conjured Mana Cake", 10, 5);
			item.Tick();
			Assert.AreEqual(8, item.Quality);
			Assert.AreEqual(4, item.SellIn);
		}
	
		[Test]
		public void TestConjuredItemAtZeroQuality()
		{
			var item = CreateItem("Conjured Mana Cake", 0, 5);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(4, item.SellIn);
		}
	
		[Test]
		public void TestConjuredItemOnSellDate()
		{
			var item = CreateItem("Conjured Mana Cake", 10, 0);
			item.Tick();
			Assert.AreEqual(6, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
	
		[Test]
		public void TestConjuredItemOnSellDateAtZeroQuality()
		{
			var item = CreateItem("Conjured Mana Cake", 0, 0);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(-1, item.SellIn);
		}
	
		[Test]
		public void TestConjuredItemAfterSellDateAtZeroQuality()
		{
			var item = CreateItem("Conjured Mana Cake", 0, -3);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(-4, item.SellIn);
		}
	
		[Test]
		public void TestConjuredItemOnAfterDateAtAlmostZeroQuality()
		{
			var item = CreateItem("Conjured Mana Cake", 1, -3);
			item.Tick();
			Assert.AreEqual(0, item.Quality);
			Assert.AreEqual(-4, item.SellIn);
		}
	}
}
