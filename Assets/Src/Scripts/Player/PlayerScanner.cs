using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerScanner : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();
    private Head _head;

    private void OnEnable()
    {
        if (_head != null)
        {
            _head.EnemyDetected += OnEnemyDetected;
            _head.EnemyLost += OnEnemyLost;
        }
    }

    private void OnDisable()
    {
        _head.EnemyDetected -= OnEnemyDetected;
        _head.EnemyLost -= OnEnemyLost;
    }

    private void OnEnemyDetected(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            return;
        }

        _enemies.Add(enemy);
    }

    private void OnEnemyLost(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

    public Enemy GetNearestEnemy()
    {
        if (_enemies.Count == 0)
            return null;

        List<KeyValuePair<float, Enemy>> enemiesOnDistance = new List<KeyValuePair<float, Enemy>>();

        foreach (var enemy in _enemies)
        {
            enemiesOnDistance.Add(new KeyValuePair<float, Enemy>(Vector3.Distance(transform.position, enemy.transform.position), enemy));
        }

        return enemiesOnDistance.OrderBy(element => element.Key).First().Value;
    }

    public void InitializeHead(Head head)
    {
        _head = head;
        OnEnable();
    }
}
