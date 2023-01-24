using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.gameObject.SetActive(true);
    }
}
