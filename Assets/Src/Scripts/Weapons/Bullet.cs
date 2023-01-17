using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Character _owner;
    private int _damage;
    private float _speed;

    public void Initialize(Character owner, int damage, float speed)
    {
        _owner = owner;
        _damage = damage;
        _speed = speed;
    }
}
