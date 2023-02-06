using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyWindow : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _stats;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private PlayerWallet _playerWallet;

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
        _description.text = $"{item.Detail.Description}\n{GetPriceDescription(item.FullPrice)}";
        _buyButton.interactable = _playerWallet.CanBuy(item.FullPrice);
    }

    private string GetPriceDescription(IEnumerable<Currency> price)
    {
        StringBuilder builder = new StringBuilder("стоимость:\n");

        foreach (Currency currency in price)
        {
            builder.Append($"{currency.Title}: {currency.Count}\n");
        }

        return builder.ToString();
    }

    private void OnBuyClicked()
    {
        _playerWallet.Buy(_item);
        DialogResult?.Invoke(_item, true);
        gameObject.SetActive(false);
    }

    private void OnCloseClicked()
    {
        DialogResult?.Invoke(_item, false);
        gameObject.SetActive(false);
    }
}
