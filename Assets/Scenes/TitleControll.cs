using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    // Method to be called when the Play button is clicked
    public void PlayGame()
    {
        // Load the next scene (e.g., your main game scene)
        SceneManager.LoadScene("SampleScene"); // Replace "MainGameScene" with the name of your main game scene
    }

    // Method to be called when the Exit button is clicked
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();

        // If running in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

