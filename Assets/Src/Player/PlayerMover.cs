using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private PlayerInput _playerInput;
    private float _speed;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        var leg = GetComponentInChildren<Leg>();
        _speed = leg != null ? leg.Speed : 0;
    }

    private void Update()
    {
        var value = _playerInput.PlayerMap.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(value.x, 0, value.y);
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
