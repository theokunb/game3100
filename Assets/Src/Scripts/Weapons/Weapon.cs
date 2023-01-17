using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _clipSize;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private Transform _shootPlace;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _bulletSpeed;

    private Character _owner;
    private float _elapsedTime;

    private void Start()
    {
        _owner = GetComponentInParent<Character>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public void Shoot()
    {
        if(_delayBetweenShoot > _elapsedTime)
        {
            return;
        }

        _elapsedTime = 0;

        var newBullet = Instantiate(_bullet, _shootPlace);
        newBullet.Initialize(_owner, _damage, _bulletSpeed);
    }
}
