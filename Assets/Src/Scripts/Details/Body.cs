using System;
using System.Collections.Generic;

public class Body : RobotDetail
{
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

    public void AddWeapons(List<Weapon> weapons)
    {
        for (int i = 0; i < _weaponPlaces.Length; i++)
        {
            if (i >= weapons.Count)
            {
                return;
            }

            _weapons.Add(Instantiate(weapons[i], _weaponPlaces[i].transform));
        }
    }
}
