using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private LevelCreator _levelCreator;
    [SerializeField] private Spawner _spawner;

    private void Start()
    {
        _levelCreator.Create(10, 30, 100);
    }
}
