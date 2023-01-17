using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Head : Detail
{
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
}
