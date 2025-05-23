using TMPro;
using UnityEngine;public class KillManager : MonoBehaviour
{
    public static KillManager Instance;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI highScoreText;

    private int killCount = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateKillText();
        UpdateHighScoreText();
    }

    public void AddKill()
    {
        killCount++;
        UpdateKillText();

        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (killCount > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", killCount);
            PlayerPrefs.Save();
            UpdateHighScoreText(); // live update UI
        }
    }

    void UpdateKillText()
    {
        killText.text = "Kills: " + killCount;
    }

    void UpdateHighScoreText()
    {
        int high = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + high;
    }

    public int GetKillCount() => killCount;
}
