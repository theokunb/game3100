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
        switch (price.CurrencyType)
        {
            case CurrencyType.Metal:
                return new CurrencyData(Currency.MetalTitle, price.Count);
            case CurrencyType.Fuel:
                return new CurrencyData(Currency.FuelTitle, price.Count);
            case CurrencyType.Energy:
                return new CurrencyData(Currency.EnegyTitle, price.Count);
            default:
                return null;
        }
    }
}
