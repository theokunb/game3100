using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameObject _weaponContainer;
    [SerializeField] private bool _spawnDrop;

    private void OnEnable()
    {
        ClearView();
        _closeButton.onClick.AddListener(CloseButtonClicked);

        foreach (var weapon in _player.WeaponPlaces.Select(weaponPlace => weaponPlace.CurrentWeapon))
        {
            if (weapon != null)
            {
                var weaponView = Instantiate(_template, _weaponContainer.transform);
                weaponView.Render(weapon.GetComponent<DetailShop>(), weapon);
                weaponView.RemoveClicked += OnRemoveClicked;
            }
        }
    }

    private void CloseButtonClicked()
    {
        GameStorage.Save(new PlayerData(_player), GameStorage.PlayerData);
        gameObject.SetActive(false);
    }

    private void OnRemoveClicked(WeaponView weaponView)
    {
        _player.DropWeapon(weaponView.Weapon, _spawnDrop);
        Destroy(weaponView.Weapon.gameObject);
        weaponView.RemoveClicked -= OnRemoveClicked;
        Destroy(weaponView.gameObject);
    }

    private void ClearView()
    {
        foreach(Transform child in _weaponContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
