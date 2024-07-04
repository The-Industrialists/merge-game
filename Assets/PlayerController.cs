using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{   


     public GameObject shrimpPrefab; // Reference to the shrimp prefab
    public GameObject tempuraPrefab; // Reference to the tempura prefab
    public GameObject sashimiPrefab; // Reference to the sashimi prefab
    public GameObject caRollPrefab; // Reference to the CA_Roll prefab
    public float moveSpeed = 5f; // Speed at which the rectangle moves
                                         // Assign the Shrimp prefab in the inspector
    public Transform shrimpSpawnPoint;
    public float spawnCooldown = 1f;
    private float nextSpawnTime = 0f;
    public int playerScore;
    public Vector3 playerPosition; 
    private List<GameObject> activeGameObjects;

    void Update()
    {
        // Handle movement
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.Escape) && Time.time >= nextSpawnTime)
        {
            SaveProgress();
            SceneManager.LoadScene("TitleScreen");
            
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            SpawnShrimp();
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }

    void SaveProgress()
    {
        // Save player progress to GameManager
        GameManager.Instance.SavePlayerProgress(playerScore, transform.position);
    }

        void Start()
    {
        // Load player progress from GameManager
        if (GameManager.Instance != null)
        {
            int score;
            Vector3 position;
            GameManager.Instance.LoadPlayerProgress(out score, out position);
            playerScore = score;
            transform.position = position;

            // Load saved game objects
            List<GameObjectData> savedGameObjects = GameManager.Instance.LoadGameObjectStates();
            foreach (var data in savedGameObjects)
            {
                GameObject prefab = GetPrefabByName(data.prefabName);
                if (prefab != null)
                {
                    GameObject newObject = Instantiate(prefab, data.position, data.rotation);
                    activeGameObjects.Add(newObject);
                }
            }
        }
        else
        {
            Debug.LogError("GameManager instance not found.");
        }
    }
   
   

    void SpawnShrimp()
    {
        // If a spawn point is assigned, use its position; otherwise, use the player's position
        Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
        Instantiate(shrimpPrefab, spawnPosition, Quaternion.identity);
    }

    GameObject GetPrefabByName(string prefabName)
    {
        switch (prefabName)
        {
            case "Shrimp":
                return shrimpPrefab;
            case "Tempura":
                return tempuraPrefab;
            case "Sashimi":
                return sashimiPrefab;
            case "CA_Roll":
                return caRollPrefab;
            default:
                return null;
        }
    }
}
