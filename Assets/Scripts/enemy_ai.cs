using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float attackRange = 10f;
    public float attackCooldown = 1.5f;
    public float projectileSpeed = 20f;

    public Transform player;
    public NavMeshAgent agent;
    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject muzzleFlashPrefab;

    private float lastAttackTime;
    public EnemyHealthBar healthBar;
    public EnemySpawner spawner;

    void Start()
    {
        if (agent != null)
            agent.stoppingDistance = 5f;

        // Automatically find HealthBar in children
        // healthBar = GetComponentInChildren<HealthBar>();
         if (player == null)
            {
                GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                if (playerObj != null)
                    player = playerObj.transform;
            }

        // Initialize health bar if found
        if (healthBar != null)
            healthBar.SetHealth(health, 100f);
    }

    void Update()
    {
        if (player == null || agent == null) return;

        agent.SetDestination(player.position);

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }
    }

    void AttackPlayer()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 dir = (player.position - firePoint.position).normalized;
                rb.linearVelocity = dir * projectileSpeed;
            }

            if (muzzleFlashPrefab != null)
            {
                GameObject flash = Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
                Destroy(flash, 0.2f);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("Enemy took damage (Takedamage method): " + amount);
        health -= amount;
        if (healthBar != null)
            healthBar.SetHealth(health, 100f);

        if (health <= 0)
        {
            if (spawner != null){
                Debug.Log("Enemy killed");
                spawner.EnemyKilled();
            }
            gameObject.SetActive(false); // Instead of Destroy
            health = 100f; // Reset health for reuse
            if (healthBar != null){
                healthBar.SetHealth(health, 100f);
            }
        }
    }

}
