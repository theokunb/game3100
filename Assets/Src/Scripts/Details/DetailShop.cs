using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detail))]
public class DetailShop : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private Price[] _prices;

    public Sprite Icon => _icon;

    public IEnumerable<CurrencyData> GetPrice()
    {
        foreach (var price in _prices)
        {
            yield return GetPrice(price);
        }
    }

    private CurrencyData GetPrice(Price price)
    {
        return new CurrencyData(Currency.GetTitle(price.CurrencyType), price.Count);
    }
}
