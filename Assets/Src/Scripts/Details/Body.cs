using System;
using System.Collections.Generic;
using System.Linq;

public class Body : RobotDetail
{
    private const string Label = "����";
    private const string WeaponSlots = "����� ������:";

    private List<Weapon> _weapons = new List<Weapon>();
    private WeaponPlace[] _weaponPlaces;

    public IEnumerable<WeaponPlace> WeaponPlaces => _weaponPlaces;

    private void Awake()
    {
        _weaponPlaces = GetComponentsInChildren<WeaponPlace>();
    }

    public void Attack(Character target)
    {
        foreach (var weapon in _weapons)
        {
            weapon.Shoot(target);
        }
    }

    public void TryAddWeapons(List<Weapon> newWeapons)
    {
        foreach (var newWeapon in newWeapons)
        {
            for (int i = 0; i < _weaponPlaces.Length; i++)
            {
                if (_weaponPlaces[i].IsBusy == false)
                {
                    _weapons.Add(Instantiate(newWeapon, _weaponPlaces[i].transform));
                    break;
                }
            }
        }

        newWeapons.Clear();
        newWeapons.AddRange(_weapons.Where(weapon => weapon != null));
    }

    public override string GetLabel()
    {
        return Label;
    }

    public override string GetSpecialStats()
    {
        return $"{WeaponSlots} {_weaponPlaces.Length}";
    }
}
