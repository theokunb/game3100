using System;

[Serializable]
public abstract class CurrencyData
{
    public CurrencyData(string title, int count)
    {
        Title = title;
        Count = count;
    }

    public string Title { get; private set; }
    public int Count { get; private set; }

    public void Add(Currency currency)
    {
        Count += currency.GetCount();
    }
}

[Serializable]
public class Metal : CurrencyData
{
    public Metal(string title, int count) : base(title, count)
    {
    }
}

[Serializable]
public class Energy : CurrencyData
{
    public Energy(string title, int count) : base(title, count)
    {
    }
}

[Serializable]
public class Fuel : CurrencyData
{
    public Fuel(string title, int count) : base(title, count)
    {
    }
}