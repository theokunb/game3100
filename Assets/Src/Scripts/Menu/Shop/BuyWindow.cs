using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BuyWindow : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _stats;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Wallet _wallet;

    private ItemShopView _item;

    public event Action<ItemShopView, bool> DialogResult;

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseClicked);
        _buyButton.onClick.AddListener(OnBuyClicked);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseClicked);
        _buyButton.onClick.RemoveListener(OnBuyClicked);
    }

    public void Render(ItemShopView item)
    {
        _item = item;
        _image.sprite = item.Image.sprite;
        _title.text = item.Detail.Title;
        _stats.text = item.Detail.GetStats();
        _description.text = item.Detail.Description;
        _price.text = MakePrice(item.Price);
        SetActiveBuyButton(item.Price);
    }

    private void SetActiveBuyButton(IEnumerable<CurrencyData> currencyDatas)
    {
        _buyButton.interactable = _wallet.CanBuy(currencyDatas);
    }

    private string MakePrice(IEnumerable<CurrencyData> currencyDatas)
    {
        StringBuilder priceText = new StringBuilder();

        foreach (var price in currencyDatas)
        {
            priceText.Append($"{price.Title} {price.Count} ");
        }

        return priceText.ToString();
    }

    private void OnBuyClicked()
    {
        _wallet.Buy(_item);
        DialogResult?.Invoke(_item, true);
        gameObject.SetActive(false);
    }

    private void OnCloseClicked()
    {
        DialogResult?.Invoke(_item, false);
        gameObject.SetActive(false);
    }
}
