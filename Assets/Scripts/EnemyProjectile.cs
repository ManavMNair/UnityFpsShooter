using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 5f;
    public float damage = 10f;

    private bool hasHit = false;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return; // Prevent multiple collisions
        hasHit = true;

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Debug.Log($"Enemy projectile hit Player and applied {damage} damage.");
            }
        }
        else
        {
            Debug.Log($"Projectile hit: {collision.gameObject.name}");
        }

        Destroy(gameObject);
    }
}
