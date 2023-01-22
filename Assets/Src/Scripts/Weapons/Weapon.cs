using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon : Detail
{
    private const int BulletsCount = 15;

    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private Transform _shootPlace;
    [SerializeField] private Bullet _template;
    [SerializeField] private float _bulletSpeed;

    private Character _owner;
    private float _elapsedTime;
    private List<Bullet> _bullets;

    public int Damage => _damage;

    private void Start()
    {
        _owner = GetComponentInParent<Character>();
        _bullets = new List<Bullet>();

        for (int i = 0; i < BulletsCount; i++)
        {
            var newBullet = Instantiate(_template, _shootPlace);
            newBullet.Initialize(_owner, _damage, _bulletSpeed);
            newBullet.gameObject.SetActive(false);
            _bullets.Add(newBullet);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    public void Shoot(Character target)
    {
        if (_delayBetweenShoot > _elapsedTime)
        {
            return;
        }

        var bullet = _bullets.Where(element => element.gameObject.activeSelf == false).FirstOrDefault();

        if (bullet == null)
        {
            return;
        }
        else
        {
            bullet.transform.position = _shootPlace.position;
            bullet.transform.LookAt(target.transform);
            bullet.gameObject.SetActive(true);
        }

        _elapsedTime = 0;
    }
}
