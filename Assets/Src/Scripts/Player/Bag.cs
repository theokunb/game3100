using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Bag : MonoBehaviour
{
    private Stack<DetailDropped> _detailsDropped;

    private void Awake()
    {
        _detailsDropped = new Stack<DetailDropped>();
    }

    public void Put(DetailDropped detailDropped)
    {
        _detailsDropped.Push(detailDropped);
    }

    public IEnumerable<DetailDropped> PopDetails()
    {
        while (_detailsDropped.TryPeek(out DetailDropped _))
        {
            yield return _detailsDropped.Pop();
        }
    }
}
