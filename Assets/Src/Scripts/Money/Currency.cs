using UnityEngine;

[CreateAssetMenu(menuName = "Currency", order = 51)]
public class Currency : ScriptableObject
{
    [SerializeField] private CurrencyDroped _template;
    [SerializeField] private CurrencyType _currencyType;
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;

    public string Title => GetTitle(_currencyType);

    public int GetCount() => Random.Range(_minCount, _maxCount);

    public static string GetTitle(CurrencyType currencyType)
    {
        const string FuelTitle = "топливо";
        const string EnegyTitle = "энергия";
        const string MetalTitle = "металлы";

        switch (currencyType)
        {
            case CurrencyType.Metal:
                return MetalTitle;
            case CurrencyType.Fuel:
                return FuelTitle;
            case CurrencyType.Energy:
                return EnegyTitle;
            default:
                return default;
        }
    }

    public CurrencyDroped CreateObject()
    {
        var createdCurrencyObject = Instantiate(_template);
        createdCurrencyObject.Initialize(_currencyType, GetCount());
        return createdCurrencyObject;
    }
}
