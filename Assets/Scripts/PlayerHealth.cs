using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth = 100f ;

    public PlayerHealthUI healthUI;    
    
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"Staring health {currentHealth}");
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {

        Debug.Log($"Current health :{currentHealth}\nPlayer took {amount} damage.");
        currentHealth -= amount;
        // currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Remaining Health: {currentHealth}");

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
            EnemySpawner spawner = FindFirstObjectByType<EnemySpawner>();
            if (spawner != null)
            {
                spawner.StopSpawning();
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthUI != null)
        {
            healthUI.SetHealth(currentHealth, maxHealth);
        }
    }

    void Die()
    {
        PlayerPrefs.SetInt("LastKillCount", KillManager.Instance.GetKillCount());
        PlayerPrefs.Save();
        SceneManager.LoadScene("EndScene");
    }

    // IEnumerator RestartAfterDelay(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
}
