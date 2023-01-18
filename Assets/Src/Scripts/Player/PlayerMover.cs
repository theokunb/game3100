using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const float DeltaStick = 0.1f;
    private const float RotationTime = 1f;
    private readonly float DeltaMove = Mathf.Sqrt(1.4f);

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

        if (value.sqrMagnitude < DeltaStick)
        {
            return;
        }

        Rotate(value);
        Move(value);
    }

    private void Rotate(Vector2 value)
    {
        float angle = Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, angle, 0)), RotationTime);
    }

    private void Move(Vector2 value)
    {
        Vector3 movement = new Vector3(0, 0, Mathf.Abs(value.y) + Mathf.Abs(value.x)) / DeltaMove;
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
