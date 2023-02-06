using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Wallet : MonoBehaviour
{
    private List<CurrencyData> _currecncies = new List<CurrencyData>();

    public event Action<CurrencyData> OnValueChanged;

    public void CreateDefault()
    {
        _currecncies.Add(new CurrencyData(Currency.GetTitle(CurrencyType.Metal), 1000));
        _currecncies.Add(new CurrencyData(Currency.GetTitle(CurrencyType.Energy), 1000));
        _currecncies.Add(new CurrencyData(Currency.GetTitle(CurrencyType.Fuel), 2000));
    }

    public void SetCurrency(IEnumerable<CurrencyData> currencyDatas)
    {
        foreach (var currencyData in currencyDatas)
        {
            _currecncies.Add(currencyData);
        }
    }

    public void Add(Currency value)
    {
        var currency = _currecncies.Where(element => element.Title == value.Title).FirstOrDefault();

        if(currency == null)
        {
            return;
        }

        currency.Increase(new CurrencyData(value.Title, value.GetCount()));
    }

    public IEnumerable<CurrencyData> GetCurrecncies() => _currecncies;

    public bool CanBuy(IEnumerable<CurrencyData> currencyDatas)
    {
        foreach(var currency in currencyDatas)
        {
            var currecy = _currecncies.Where(element => element.Title == currency.Title);

            if(currecy.Count() > 1)
            {
                return false;
            }

            if (currecy.FirstOrDefault().Count < currency.Count)
            {
                return false;
            }
        }

        return true;
    }

    public void Buy(ItemShopView item)
    {
        Pay(item.Price);
        item.Detail.Unlock();

        GameStorage.Save(new PlayerData(GetComponent<Player>()), GameStorage.PlayerData);
    }

    private void Pay(IEnumerable<CurrencyData> currencyDatas)
    {
        foreach(var currency in currencyDatas)
        {
            var myCurrency = _currecncies.Where(element => element.Title == currency.Title).FirstOrDefault();
            myCurrency.Decrease(currency);

            OnValueChanged?.Invoke(myCurrency);
        }
    }
}
