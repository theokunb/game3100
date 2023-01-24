using UnityEngine;
using UnityEngine.UI;

public class DetailShop : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;

    public Sprite Icon => _icon;
}
