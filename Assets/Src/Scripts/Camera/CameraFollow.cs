using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _offset;

    private float _zPosition;

    private void Start()
    {
        _zPosition = _target.transform.position.z - transform.position.z;
    }

    private void Update()
    {
        float newZ = _target.transform.position.z - transform.position.z;

        if (Mathf.Abs(newZ - _zPosition) > _offset)
        {
            Vector3 movement = new Vector3(0,0, newZ - _zPosition);

            transform.position += movement * Time.deltaTime;
        }
    }
}
