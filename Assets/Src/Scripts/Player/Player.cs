using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Start()
    {
        CorrectDetails(LegPosition);
        Save();
    }

    public void Save()
    {
        GameStorage.Save(new PlayerData(this), GameStorage.PlayerData);
    }

    public void DropWeapon(Weapon weapon)
    {
        Weapons.Remove(weapon);
        Destroy(weapon.gameObject);
    }
}
