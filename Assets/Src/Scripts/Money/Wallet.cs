using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private List<CurrencyData> _currecncies = new List<CurrencyData>();

    public event Action<CurrencyData> OnValueChanged;

    public void CreateDefault()
    {
        _currecncies.Add(new Metal("металлы", 10));
        _currecncies.Add(new Energy("энергия", 0));
        _currecncies.Add(new Fuel("топливо", 20));
    }

    public void SetCurrency(IEnumerable<CurrencyData> currencyDatas)
    {
        foreach (var currencyData in currencyDatas)
        {
            _currecncies.Add(currencyData);
        }
    }

    public IEnumerable<CurrencyData> GetCurrecncies() => _currecncies;

    public void Add(Currency currency)
    {
        var currencyData = _currecncies.Where(elenemt => elenemt.Title == currency.Title).FirstOrDefault();

        if (currencyData == null)
            return;

        currencyData.Add(currency);
        OnValueChanged?.Invoke(currencyData);
    }
}
