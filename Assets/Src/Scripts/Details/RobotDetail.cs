using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class RobotDetail : Detail
{
    protected const string BonusHealth = "дополнительное здоровье:";

    [SerializeField] private Transform _upperPlaceOfDetail;
    [SerializeField] private int _bonusHealth;

    public Transform UpperPlaceOfDetail => _upperPlaceOfDetail;

    public override string GetStats()
    {
        return $"{BonusHealth} {_bonusHealth}\n{GetSpecialStats()}";
    }

    public abstract string GetSpecialStats();
}
