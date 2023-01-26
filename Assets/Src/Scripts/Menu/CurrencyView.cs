using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private DisplayCurrency[] _templates;

    private List<DisplayCurrency> _objects = new List<DisplayCurrency>();

    private void OnEnable()
    {
        _wallet.OnValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _wallet.OnValueChanged -= OnValueChanged;
    }

    private void Start()
    {
        foreach (var currencyData in _wallet.GetCurrecncies())
        {
            var template = _templates.Where(element => element.Title == currencyData.Title).FirstOrDefault();

            if (template != null)
            {
                var displayCurrency = Instantiate(template, _container.transform);
                displayCurrency.Render(currencyData);
                _objects.Add(displayCurrency);
            }
        }
    }

    private void OnValueChanged(CurrencyData currencyData)
    {
        var changedelement = _objects.Where(elemeint => elemeint.Title == currencyData.Title).FirstOrDefault();

        if(changedelement == null)
        {
            return;
        }

        changedelement.Render(currencyData);
    }
}
