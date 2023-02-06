using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Bag : MonoBehaviour
{
    private Stack<DetailDropped> _detailsDropped;
    private Stack<CurrencyDroped> _currencyDropped;

    private void Awake()
    {
        _detailsDropped = new Stack<DetailDropped>();
        _currencyDropped = new Stack<CurrencyDroped>();
    }

    public void Put(DetailDropped detailDropped)
    {
        _detailsDropped.Push(detailDropped);
    }

    public void Put(CurrencyDroped currencyDroped)
    {
        _currencyDropped.Push(currencyDroped);
    }

    public IEnumerable<DetailDropped> PopDetails()
    {
        while (_detailsDropped.TryPeek(out DetailDropped _))
        {
            yield return _detailsDropped.Pop();
        }
    }

    public IEnumerable<CurrencyDroped> PopCurrencies()
    {
        while (_currencyDropped.TryPeek(out CurrencyDroped _))
        {
            yield return _currencyDropped.Pop();
        }
    }
}
