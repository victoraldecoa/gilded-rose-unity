using System.Collections.Generic;
using GildedRose.GildedItems;
using UnityEngine;

namespace GildedRose
{
	public class GildedRoseRunner : MonoBehaviour
	{
		[SerializeField] GildedItemsPresenter _presenter;
		
		IList<IGildedItem> _items;
		readonly GildedItemFactory _itemFactory = new GildedItemFactory();
		
		IGildedItem CreateItem(string itemName, int quality, int sellIn)
		{
			return _itemFactory.CreateItem(itemName, quality, sellIn);
		}
		
		void Awake()
		{
			_items = new List<IGildedItem>
			{
				CreateItem("+5 Dexterity Vest", 20, 10),
				CreateItem("Aged Brie", 0, 2),
				CreateItem("Elixir of the Mongoose", 7, 5),
				CreateItem("Sulfuras, Hand of Ragnaros", 80, 0),
				CreateItem("Sulfuras, Hand of Ragnaros", 80, -1),
				CreateItem("Backstage passes to a TAFKAL80ETC concert", 20, 15),
				CreateItem("Backstage passes to a TAFKAL80ETC concert", 49, 10),
				CreateItem("Backstage passes to a TAFKAL80ETC concert", 49, 5),
				CreateItem("Conjured Mana Cake", 6, 3),
				CreateItem("Conjured Mana Cake", 15, 1)
			};
		}

		void Start()
		{
			_presenter.Create(_items);
		}

		public void Tick()
		{
			foreach (var item in _items)
			{
				item.Tick();
			}
			_presenter.UpdateItems(_items);
		}
	}
}
