using UnityEngine;

public class Reward : MonoBehaviour
{
    private const int AllProbability = 100;
    private const int CurrencyDropChance = 60;

    [SerializeField] private Currency[] _currency;
    [SerializeField] private ItemsPull _dropItems;

    public GameObject GetReward()
    {
        int dropChance = 100;

        int roll = Random.Range(0, AllProbability);

        if(roll > dropChance)
        {
            return null;
        }
        else
        {
            roll = Random.Range(0, AllProbability);

            if(roll < CurrencyDropChance)
            {
                return GetRandomCurrency();
            }
            else
            {
                return GetRandomItem();
            }
        }
    }

    private GameObject GetRandomCurrency()
    {
        int randomIndex = Random.Range(0, _currency.Length);

        return _currency[randomIndex].CreateObject().gameObject;
    }

    private GameObject GetRandomItem()
    {
        return _dropItems.GetRandomDetail()?.gameObject;
    }
}
