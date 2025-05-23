using UnityEngine;

public class Target_script : MonoBehaviour
{
    public float health = 100f;
    public EnemyHealthBar healthBar;
    public EnemySpawner spawner;

    void Start()
    {
        // Dynamically find the EnemySpawner in the scene if not already set
        if (spawner == null)
        {
            spawner = FindObjectOfType<EnemySpawner>();
            if (spawner == null)
            {
                Debug.LogWarning("No EnemySpawner found in the scene.");
            }
        }
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Enemy took damage (Target.Takedamage method): " + amount);
        health -= amount;
        if (healthBar != null)
        {
            healthBar.SetHealth(health, 100f);
        }


        if (health <= 0)
        {
            if (spawner != null)
            {
                Debug.Log("Enemy killed");
                spawner.EnemyKilled();
            }
            if (KillManager.Instance != null)
            {
                KillManager.Instance.AddKill();
            }
            gameObject.SetActive(false); // Instead of Destroy
            health = 100f; // Reset health for reuse
            if (healthBar != null)
            {
                healthBar.SetHealth(health, 100f);
            }
        }

    }

}
