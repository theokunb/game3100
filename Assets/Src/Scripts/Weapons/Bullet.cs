using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private Character _owner;
    private int _damage;
    private float _speed;
    private float _elapsedTime;

    public void Initialize(Character owner, int damage, float speed)
    {
        _owner = owner;
        _damage = damage;
        _speed = speed;
        transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _lifeTime)
        {
            ResetBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            if (character.GetType() != _owner.GetType())
            {
                var health = character.GetComponent<Health>();
                health.TakeDamage(_damage);

                character.SetWhoAttacked(_owner);
                ResetBullet();
            }
        }
    }

    private void ResetBullet()
    {
        _elapsedTime = 0;
        gameObject.SetActive(false);
    }
}
