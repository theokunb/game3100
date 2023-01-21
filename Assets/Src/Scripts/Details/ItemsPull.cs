using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Details", menuName = "ItemsPull", order = 51)]
public class ItemsPull : ScriptableObject
{
    [SerializeField] private List<Detail> _details;

    public IEnumerable<Detail> Details => _details;

    public void AddDetail(Detail detail)
    {
        _details.Add(detail);
    }
}
