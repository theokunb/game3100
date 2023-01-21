using System;
using UnityEngine;

[Serializable]
public class Pack
{
    [SerializeField] private Enemy[] _enemies;

    public void Create(float position, float width)
    {
        var step = width / _enemies.Length;

        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Create(new Vector2(step / 2 + i * step, position));
        }
    }
}
