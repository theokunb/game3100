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
        _leg.SetPosition(_legPosition);
        _body.SetPosition(_leg.UpperPlaceOfDetail);
        _head.SetPosition(_body.UpperPlaceOfDetail);
        _body.AddWeapons(_weapons);

        GameStorage.SavePlayer(this);
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
        _leg = Instantiate(leg, transform);
    }

    public void SetDetail(Body body)
    {
        _body = Instantiate(body, transform);
    }

    public void SetDetail(Head head)
    {
        _scanner = GetComponent<PlayerScanner>();

        _head = Instantiate(head, transform);
        _scanner.InitializeHead(_head);
    }

    public void SetDetail(Weapon weapon)
    {
        _weapons.Add(weapon);
    }
}
