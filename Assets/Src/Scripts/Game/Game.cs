using UnityEngine;
using IJunior.TypedScenes;

public class Game : MonoBehaviour, ISceneLoadHandler<int>
{
    private const int HeightPlatform = 10;

    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerLoader _playerLoader;
    [SerializeField] private Player _player;
    [SerializeField] private LevelsContainer _levelContainer;

    private int _currentLevel;

    public void OnSceneLoaded(int argument)
    {
        _currentLevel = argument;
    }

    private void Start()
    {
        Level currentLevel = _levelContainer.GetLevel(_currentLevel);

        _levelCreator.Create(currentLevel.Width, currentLevel.Lenght, HeightPlatform);
        _spawner.CreateEnemyPacks(currentLevel.Enemies, new Rectangle(currentLevel.Width, currentLevel.Lenght));
        _spawner.PutToStartPosition(_player, new Rectangle(currentLevel.Width, currentLevel.Lenght));
    }
}
