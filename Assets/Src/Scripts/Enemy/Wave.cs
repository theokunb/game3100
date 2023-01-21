using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private Pack[] _packs;

    public Pack[] Packs => _packs;
}
