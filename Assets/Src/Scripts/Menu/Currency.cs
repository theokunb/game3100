using UnityEngine;

[CreateAssetMenu(menuName = "Currency", order = 51)]
public class Currency : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;

    public string Title => _title;
    public int GetCount() => Random.Range(_minCount, _maxCount);
}
