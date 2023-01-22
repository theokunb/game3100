using UnityEngine;

[RequireComponent(typeof(DetailShop))]
public class Detail : MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private bool _isAvailable;

    public string Title => _title;
    public bool IsAvailable => _isAvailable;

    public void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

    public void Unlock()
    {
        _isAvailable = true;
    }
}
