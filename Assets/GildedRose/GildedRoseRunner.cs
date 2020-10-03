using System.Collections.Generic;
using System.Linq;
using GildedRose.GildedItems;
using UnityEngine;

namespace GildedRose
{
	struct ItemDataTickerPair
	{
		static readonly TickFunctionFactory TickFactory = new TickFunctionFactory();
		
		public string Name;
		public ItemData Data;
		
		public static ItemDataTickerPair CreateItem(string name, int quality, int sellIn)
		{
			return new ItemDataTickerPair
			{
				Name = name,
				Data = new ItemData { Quality = quality, SellIn = sellIn, Tick = TickFactory.CreateTickFunction(name)}
			};
		}
	}
	
	public class GildedRoseRunner : MonoBehaviour
	{
		[SerializeField] GildedItemsPresenter _presenter;
		
		IList<ItemDataTickerPair> _items;
		
		void Awake()
		{
			_items = new List<ItemDataTickerPair>
			{
				ItemDataTickerPair.CreateItem("+5 Dexterity Vest", 20, 10),
				ItemDataTickerPair.CreateItem("Aged Brie", 0, 2),
				ItemDataTickerPair.CreateItem("Elixir of the Mongoose", 7, 5),
				ItemDataTickerPair.CreateItem("Sulfuras, Hand of Ragnaros", 80, 0),
				ItemDataTickerPair.CreateItem("Sulfuras, Hand of Ragnaros", 80, -1),
				ItemDataTickerPair.CreateItem("Backstage passes to a TAFKAL80ETC concert", 20, 15),
				ItemDataTickerPair.CreateItem("Backstage passes to a TAFKAL80ETC concert", 49, 10),
				ItemDataTickerPair.CreateItem("Backstage passes to a TAFKAL80ETC concert", 49, 5),
				ItemDataTickerPair.CreateItem("Conjured Mana Cake", 6, 3),
				ItemDataTickerPair.CreateItem("Conjured Mana Cake", 15, 1)
			};
		}

		void Start()
		{
			_presenter.Create(CreateDataList());
		}

		public void Tick()
		{
			for (var i = 0; i < _items.Count; i++)
			{
				var item = _items[i];
				item.Data = item.Data.Tick(item.Data);
				_items[i] = item;
			}
			_presenter.UpdateItems(CreateDataList());
		}

		IList<ItemViewData> CreateDataList()
		{
			return _items.Select(i => new ItemViewData
			{
				Name = i.Name,
				Quality = i.Data.Quality,
				SellIn = i.Data.SellIn
			}).ToArray();
		}
	}
}
