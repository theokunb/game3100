using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Bag : MonoBehaviour
{
    private Queue<DetailDropped> _detailsDropped;
    private Queue<DroppedCurrency> _currenciesDropped;

    private void Awake()
    {
        _detailsDropped = new Queue<DetailDropped>();
        _currenciesDropped = new Queue<DroppedCurrency>();
    }

    public void Put(DetailDropped detailDropped)
    {
        _detailsDropped.Enqueue(detailDropped);
    }

    public void Put(DroppedCurrency currencyDropped)
    {
        _currenciesDropped.Enqueue(currencyDropped);
    }

    public IEnumerable<DetailDropped> GetDetails()
    {
        while (_detailsDropped.Count > 0)
        {
            yield return _detailsDropped.Dequeue();
        }
    }

    public IEnumerable<DroppedCurrency> GetCurrencies()
    {
        while (_currenciesDropped.Count > 0)
        {
            yield return _currenciesDropped.Dequeue();
        }
    }
}
