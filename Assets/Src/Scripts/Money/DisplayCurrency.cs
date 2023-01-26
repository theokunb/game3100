using TMPro;
using UnityEngine;

public class DisplayCurrency : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _title;

    public string Title => _title;

    public void Render(CurrencyData currencyData)
    {
        _text.text = currencyData.Count.ToString();
    }
}
