using UnityEngine;

public class Leg : RobotDetail
{
    private const string Label = "ноги";
    private const string MoveSpeed = "скорость передвижения:";

    [SerializeField] private float _speed;

    public float Speed => _speed;

    public override string GetLabel()
    {
        return Label;
    }

    public override string GetSpecialStats()
    {
        return $"{MoveSpeed} {Speed}";
    }
}
