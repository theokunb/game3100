using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : RobotDetail
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}
