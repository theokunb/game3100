using System;

[Serializable]
public class CurrencyData
{
    public CurrencyData(string title, int count)
    {
        Title = title;
        Count = count;
    }

    public string Title { get; private set; }
    public int Count { get; private set; }

    public void Decrease(CurrencyData currency)
    {
        Count -= currency.Count;
    }
}