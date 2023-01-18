public class Body : Detail
{
    private Weapon[] _weapons;

    private void Start()
    {
        _weapons = GetComponentsInChildren<Weapon>();
    }

    public void Attack(Character target)
    {
        foreach (var weapon in _weapons)
        {
            weapon.Shoot(target);
        }
    }
}
