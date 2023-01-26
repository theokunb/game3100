using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerScanner))]
public class Player : Character
{
    [SerializeField] private Transform _legPosition;

    private PlayerScanner _scanner;
    private Leg _leg;
    private Body _body;
    private Head _head;
    private List<Weapon> _weapons = new List<Weapon>();

    public IEnumerable<WeaponPlace> WeaponPlaces => _body.WeaponPlaces;

    private void Start()
    {
        CorrectDetails();
        Save();
    }

    private void Update()
    {
        var target = _scanner.GetNearestEnemy();

        if (target != null)
        {
            _body.transform.LookAt(target.transform);
            _body.Attack(target);
        }
    }

    public void CorrectDetails()
    {
        _leg.SetPosition(_legPosition);
        _body.SetPosition(_leg.UpperPlaceOfDetail);
        _head.SetPosition(_body.UpperPlaceOfDetail);
        _body.TryAddWeapons(_weapons);
    }

    public void Save()
    {
        GameStorage.Save(new PlayerData(this));
    }

    public IEnumerable<DetailData> GetAllDetails()
    {
        var details = GetComponentsInChildren<Detail>();

        foreach (var detail in details)
        {
            yield return new DetailData(detail.Title);
        }
    }

    public void SetDetail(Leg leg)
    {
        Destroy(_leg?.gameObject);
        _leg = Instantiate(leg, transform);
    }

    public void SetDetail(Body body)
    {
        Destroy(_body?.gameObject);
        _body = Instantiate(body, transform);
    }

    public void SetDetail(Head head)
    {
        Destroy(_head?.gameObject);
        _scanner = GetComponent<PlayerScanner>();

        _head = Instantiate(head, transform);
        _scanner.InitializeHead(_head);
    }

    public void SetDetail(Weapon weapon)
    {
        _weapons.Add(weapon);
    }

    public void DropWeapon(Weapon weapon, bool isSpawnDrop)
    {
        _weapons.Remove(weapon);
        
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
