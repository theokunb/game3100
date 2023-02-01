using System;
using System.Collections.Generic;
using UnityEngine;

public class Act : MonoBehaviour
{
    [SerializeField] private LevelView _template;
    [SerializeField] private GameObject _container;

    private List<LevelView> _levels = new List<LevelView>();

    public event Action<Level> LevelSelected;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    public void Create(LevelsContainer levelContainer, PlayerProgress progress)
    {
        foreach (var level in levelContainer.Levels)
        {
            var createdLevel = Instantiate(_template, _container.transform);
            createdLevel.Render(level, progress.GetStatus(level.Id));

            _levels.Add(createdLevel);
        }

        Subscribe();
    }

    private void Subscribe()
    {
        foreach(var element in _levels)
        {
            element.LevelSelected += OnLevelSelected;
        }
    }

    private void UnSubscribe()
    {
        foreach (var element in _levels)
        {
            element.LevelSelected -= OnLevelSelected;
        }
    }

    private void OnLevelSelected(Level level)
    {
        LevelSelected?.Invoke(level);
    }
}
