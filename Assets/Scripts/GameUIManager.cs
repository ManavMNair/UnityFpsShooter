using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text scoreText; // Assign in inspector
    public GameObject gameOverPanel; // UI panel to show on game over (assign in inspector)

    private EnemySpawner enemySpawner;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        int finalScore = enemySpawner.GetKillCount();
        scoreText.text = "Final Score: " + finalScore;
    }
}
