using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Level/New Level",order = 51)]
public class Level : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private int _width;
    [SerializeField] private int _lenght;
    [SerializeField] private Pack[] _enemies;
    [SerializeField] private List<Currency> _reward;
    [SerializeField] private int _rewardCountInDay;

    public int Id => _id;
    public Pack[] Enemies => _enemies;
    public int Width => _width;
    public int Lenght => _lenght;
}