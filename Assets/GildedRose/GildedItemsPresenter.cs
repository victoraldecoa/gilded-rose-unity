using System.Collections.Generic;
using System.Linq;
using GildedRose.GildedItems;
using UnityEngine;
using UnityEngine.UI;

namespace GildedRose
{
    public class GildedItemsPresenter : MonoBehaviour
    {
        [SerializeField] GameObject _list;
        [SerializeField] GameObject _itemPrefab;

        List<Text> _itemViews;

        public void Create(IEnumerable<IGildedItem> items)
        {
            _itemViews = items.Select(item =>
            {
                var text = Instantiate(_itemPrefab).GetComponent<Text>();
                text.transform.SetParent(_list.transform);
                SetView(text, item);
                return text;
            }).ToList();
        }

        public void UpdateItems(IList<IGildedItem> items)
        {
            for (var i = 0; i < items.Count && i < _itemViews.Count; i++)
            {
                var item = items[i];
                var view = _itemViews[i];
                SetView(view, item);
            }
        }
        
        static void SetView(Text text, IGildedItem item)
        {
            text.text = string.Format("Name: {0}\n" +
                                      "Quality: {1}\n" +
                                      "Sell in: {2}",
                item.Name,
                item.Quality,
                item.SellIn);
        }
    }
}