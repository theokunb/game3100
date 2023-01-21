using System;
using UnityEditor;
using UnityEngine;
using IJunior.TypedScenes;

public class Game : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerLoader _playerLoader;
    [SerializeField] private Player _player;

    private void Start()
    {
        var wave = GetComponent<Wave>();

        int width = 10;
        int length = 30;

        _levelCreator.Create(width, length, 100);
        _spawner.CreateEnemyPacks(wave.Packs, new Rectangle(width, length));
        _spawner.PutToStartPosition(_player, new Rectangle(width, length));
    }
}
