using System;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private List<LevelsContainer> _levelsContainer;
    [SerializeField] private PlayerLoader _loader;
    [SerializeField] private Act _template;
    [SerializeField] private GameObject _container;

    private List<Act> _acts = new List<Act>();

    public event Action<Level> CurrentLevelChanged;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void Start()
    {
        foreach (var act in _levelsContainer)
        {
            var createdAct = Instantiate(_template, _container.transform);
            createdAct.Create(act, _loader.PlayerProgress);

            _acts.Add(createdAct);
        }

        Subscribe();
    }

    private void Subscribe()
    {
        foreach (var element in _acts)
        {
            element.LevelSelected += OnLevelSelected;
        }
    }

    private void UnSubscribe()
    {
        foreach (var element in _acts)
        {
            element.LevelSelected -= OnLevelSelected;
        }
    }

    private void OnLevelSelected(Level level)
    {
        CurrentLevelChanged?.Invoke(level);
    }
}
