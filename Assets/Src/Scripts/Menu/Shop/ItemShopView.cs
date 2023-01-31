using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopView : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _lockedIcon;

    public event Action<ItemShopView> BuyButtonClicked;

    public IEnumerable<CurrencyData> Price { get; private set; }
    public Detail Detail { get; private set; }
    public Image Image => _image;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyClicked);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyClicked);
    }

    public void Render(DetailShop detailShop)
    {
        _image.sprite = detailShop.Icon;
        Detail = detailShop.GetComponent<Detail>();
        Price = detailShop.GetPrice();
    }

    private void OnBuyClicked()
    {
        BuyButtonClicked?.Invoke(this);
    }
}
