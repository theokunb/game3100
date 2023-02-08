using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    protected Character Owner { get; private set; }
    protected int Damage { get; private set; }
    protected float Speed { get; private set; }
    protected float ElapsedTime { get; private set; }

    private void Update()
    {
        Fly();
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime >= _lifeTime)
        {
            LifeTimeExpired();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            if (character.GetType() != Owner.GetType())
            {
                Hit(character);
            }
        }
    }

    public void Initialize(Character owner, int damage, float speed)
    {
        Owner = owner;
        Damage = damage;
        Speed = speed;
        transform.parent = null;
    }

    protected void ResetBullet()
    {
        ElapsedTime = 0;
        gameObject.SetActive(false);
    }

    protected abstract void Fly();
    protected abstract void Hit(Character character);
    protected abstract void LifeTimeExpired();
}
