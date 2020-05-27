using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GildedRose
{
    public struct ItemViewData
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
    
    public class GildedItemsPresenter : MonoBehaviour
    {
        [SerializeField] GameObject _list;
        [SerializeField] GameObject _itemPrefab;

        List<Text> _itemViews;

        public void Create(IEnumerable<ItemViewData> items)
        {
            _itemViews = items.Select(item =>
            {
                var text = Instantiate(_itemPrefab).GetComponent<Text>();
                text.transform.SetParent(_list.transform);
                SetView(text, item);
                return text;
            }).ToList();
        }

        public void UpdateItems(IList<ItemViewData> items)
        {
            for (var i = 0; i < items.Count && i < _itemViews.Count; i++)
            {
                var item = items[i];
                var view = _itemViews[i];
                SetView(view, item);
            }
        }
        
        static void SetView(Text text, ItemViewData item)
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