using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Example game state variables
    public int playerScore;
    public Vector3 playerPosition;
    public List<GameObjectData> gameObjectStates;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
            gameObjectStates = new List<GameObjectData>();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

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

    public void SaveGameObjectStates(List<GameObjectData> gameObjectData)
    {
        gameObjectStates = gameObjectData;
    }

    public List<GameObjectData> LoadGameObjectStates()
    {
        return gameObjectStates;
    }
}

[System.Serializable]
public class GameObjectData
{
    public Vector3 position;
    public Quaternion rotation;
    public string prefabName;
}
