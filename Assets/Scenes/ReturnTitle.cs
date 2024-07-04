using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadTitleScreen();
        }
    }

    void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen"); // Replace "TitleScreen" with the actual name of your title screen scene
    }
}

