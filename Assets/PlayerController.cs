using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the rectangle moves
    public GameObject shrimpPrefab; // Assign the Shrimp prefab in the inspector
    public Transform shrimpSpawnPoint;
    public float spawnCooldown = 1f;
    private float nextSpawnTime = 0f;
    public int playerScore;
    public Vector3 playerPosition;// Assign the spawn point (optional)

    void Update()
    {
        // Handle movement
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            SaveProgress();
            SceneManager.LoadScene("TitleScreen");
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
        int score;
        Vector3 position;
        GameManager.Instance.LoadPlayerProgress(out score, out position);
        playerScore = score;
        transform.position = position;
    }

    void SpawnShrimp()
    {
        // If a spawn point is assigned, use its position; otherwise, use the player's position
        Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
        Instantiate(shrimpPrefab, spawnPosition, Quaternion.identity);
    }
}
