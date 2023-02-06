using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/New Level", order = 51)]
public class Level : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _title;
    [SerializeField] private int _width;
    [SerializeField] private int _lenght;
    [SerializeField] private Pack[] _enemies;
    [SerializeField] private List<Currency> _reward;
    [SerializeField] private int _rewardCountInDay;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Currency[] _rewards;

    public int Id => _id;
    public string Title => _title;
    public Pack[] Enemies => _enemies;
    public int Width => _width;
    public int Lenght => _lenght;
    public Sprite Icon => _icon;
    public IEnumerable<Currency> Rewards => _reward;
}