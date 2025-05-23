using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneTransition scenetransition;

    // This function starts the game by loading the first scene.
    public void StartGame()
    {
        scenetransition.LoadScene("SampleScene"); // Replace with your actual scene name
    }

    // This function exits the game.
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
