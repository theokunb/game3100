using TMPro;
using UnityEngine;

public class DisplayCurrency : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CurrencyType _currencyType;

    public string Title => Currency.GetTitle(_currencyType);

    public void Render(CurrencyData currencyData)
    {
        _text.text = currencyData.Count.ToString();
    }
}
