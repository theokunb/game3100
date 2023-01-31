using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Head : RobotDetail
{
    private const string Label = "голова";
    private const string Radius = "дальность видимости:";

    [SerializeField] private float _scannerRadius;

    private CapsuleCollider _scannerCollider;

    public event Action<Enemy> EnemyDetected;
    public event Action<Enemy> EnemyLost;

    public int ScannerRadius => (int)_scannerRadius;

    private void Start()
    {
        _scannerCollider = GetComponent<CapsuleCollider>();
        _scannerCollider.radius = _scannerRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            EnemyDetected?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            EnemyLost?.Invoke(enemy);
        }
    }

    public override string GetLabel()
    {
        return Label;
    }

    public override string GetSpecialStats()
    {
        return $"{Radius} {_scannerRadius}m";
    }
}
