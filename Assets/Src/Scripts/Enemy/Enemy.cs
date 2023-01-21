using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Enemy : Character
{
    public void Create(Vector2 position)
    {
        var collider = GetComponent<BoxCollider>();
        Vector3 spawnPosition = new Vector3(position.x, collider.size.y / 2, position.y);

        Instantiate(this, spawnPosition, Quaternion.identity);
    }
}
