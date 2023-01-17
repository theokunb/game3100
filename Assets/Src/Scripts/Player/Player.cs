using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Head _head;
    [SerializeField] private Body _body;
    [SerializeField] private Leg _leg;

    private List<Enemy> _enemies;

    private void Awake()
    {
        _enemies = new List<Enemy>();
    }

    private void OnEnable()
    {
        _head.EnemyDetected += OnEnemyDetected;
        _head.EnemyLost += OnEnemyLost;
    }

    private void OnDisable()
    {
        _head.EnemyDetected -= OnEnemyDetected;
        _head.EnemyLost -= OnEnemyLost;
    }

    private void Start()
    {
        _body.transform.position = _leg.UpperPlaceOfDetail.position;
        _head.transform.position = _body.UpperPlaceOfDetail.position;

    }

    private void Update()
    {
        var target = FindNearestEnemy(_enemies);

        if(target != null)
        {
            _body.transform.LookAt(target.transform);
        }
    }

    private Enemy FindNearestEnemy(List<Enemy> enemies)
    {
        if (enemies.Count == 0)
            return null;

        Dictionary<float, Enemy> enemiesOnDistance = new Dictionary<float, Enemy>();

        foreach(var enemy in enemies)
        {
            enemiesOnDistance.Add(Vector3.Distance(transform.position, enemy.transform.position), enemy);
        }

        return enemiesOnDistance.OrderBy(element => element.Key).First().Value;
    }

    private void OnEnemyDetected(Enemy enemy)
    {
        if(_enemies.Contains(enemy))
        {
            return;
        }

        _enemies.Add(enemy);
    }

    private void OnEnemyLost(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }
}
