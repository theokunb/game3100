using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CurrencyDroped : MonoBehaviour
{
    public CurrencyType CurrencyType { get; private set; }
    public int Count { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.GetComponent<Bag>().Put(this);
            gameObject.SetActive(false);
        }
    }

    public void Initialize(CurrencyType currencyType, int count)
    {
        CurrencyType = currencyType;
        Count = count;
    }
}

public static class CurrencyDroppedExtension
{
    public static CurrencyData ToCurrencyData(this CurrencyDroped currencyDroped)
    {
        return new CurrencyData(Currency.GetTitle(currencyDroped.CurrencyType), currencyDroped.Count);
    }
}
