using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ItemsCollectionView : MonoBehaviour
{
    [SerializeField] private ItemShopView _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private TMP_Text _label;

    private List<ItemShopView> _items;

    public event Action<ItemShopView> ItemSelected;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        foreach(var item in _items)
        {
            item.BuyButtonClicked -= DetailBuyButtonClicked;
        }
    }

    private void Awake()
    {
        _items= new List<ItemShopView>();
    }

    public void Render(IEnumerable<DetailShop> details)
    {
        var firstDetail = details.FirstOrDefault();
        
        if(firstDetail != null)
        {
            _label.text = firstDetail.GetComponent<Detail>().GetLabel();
        }

        foreach(var detail in details)
        {
            var createdDetail = Instantiate(_template, _container.transform);
            createdDetail.Render(detail);
            _items.Add(createdDetail);
        }

        Subscribe();
    }

    private void DetailBuyButtonClicked(ItemShopView obj)
    {
        ItemSelected?.Invoke(obj);
    }

    private void Subscribe()
    {
        foreach(var item in _items)
        {
            item.BuyButtonClicked += DetailBuyButtonClicked;
        }
    }
}
