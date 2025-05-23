using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        killsText.text = "Kills: " + PlayerPrefs.GetInt("LastKillCount", 0);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
