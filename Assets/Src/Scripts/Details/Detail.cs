using UnityEngine;

public class Detail : MonoBehaviour
{
    private const int MaxLevel = 5;

    [SerializeField] private string _title;
    [SerializeField] private int _level;
    [SerializeField] private bool _isAvailable;
    
    public string Title => _title;
    public bool IsAvailable => _isAvailable;
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            if(value > MaxLevel)
            {
                _level = MaxLevel;
            }
            else
            {
                _level = value;
            }
        }
    }

    public void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

    public void IncreaseLevel()
    {
        Level++;
    }

    public void Unlock()
    {
        _isAvailable = true;
    }
}
