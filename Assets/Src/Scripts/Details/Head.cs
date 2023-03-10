using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Head : RobotDetail
{
    private const string Label = "??????";
    private const string Radius = "????????? ?????????:";

    [SerializeField] private float _scannerRadius;

    private CapsuleCollider _scannerCollider;

    public event Action<Character> EnemyDetected;
    public event Action<Character> EnemyLost;

    public int ScannerRadius => (int)_scannerRadius;

    private void Start()
    {
        _scannerCollider = GetComponent<CapsuleCollider>();
        _scannerCollider.radius = _scannerRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Character enemy))
        {
            EnemyDetected?.Invoke(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Character enemy))
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
