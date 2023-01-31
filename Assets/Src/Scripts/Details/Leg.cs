using UnityEngine;

public class Leg : RobotDetail
{
    private const string Label = "����";
    private const string MoveSpeed = "�������� ������������:";

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
