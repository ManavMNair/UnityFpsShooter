using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    public GameObject crosshairImage; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

public void TogglePause()
{
    if (Time.timeScale == 1f)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        if (crosshairImage != null) crosshairImage.SetActive(false); 
    }
    else
    {
        ResumeGame();
    }
}

public void ResumeGame()
{
    Time.timeScale = 1f;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    pauseMenuUI.SetActive(false);
    if (crosshairImage != null) crosshairImage.SetActive(true); 
}


    public void RestartGame()
{
    Time.timeScale = 1f; // Make sure game isn't paused
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); // Change to your main menu scene name
    }
}
