using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Price
{
    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private int _count;

    public CurrencyType CurrencyType => _currencyType;
    public int Count => _count;
}

public enum CurrencyType
{
    Fuel,
    Metal,
    Energy
}