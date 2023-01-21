using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RobotDetail : Detail
{
    [SerializeField] private Transform _upperPlaceOfDetail;

    public Transform UpperPlaceOfDetail => _upperPlaceOfDetail;
}
