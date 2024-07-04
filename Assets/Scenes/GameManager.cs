using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Example game state variables
    public int playerScore;
    public Vector3 playerPosition;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Methods to manage game state
    public void SavePlayerProgress(int score, Vector3 position)
    {
        playerScore = score;
        playerPosition = position;
    }

    public void LoadPlayerProgress(out int score, out Vector3 position)
    {
        score = playerScore;
        position = playerPosition;
    }
}
