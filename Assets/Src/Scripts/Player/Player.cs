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

    public void DropWeapon(Weapon weapon, bool isSpawnDrop)
    {
        Weapons.Remove(weapon);
        
        if(isSpawnDrop == false)
        {
            Destroy(weapon.gameObject);
        }
        else
        {
            Instantiate(weapon, transform.position, Quaternion.identity);
        }
    }
}
