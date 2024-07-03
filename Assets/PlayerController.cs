using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the rectangle moves
    public GameObject shrimpPrefab; // Assign the Shrimp prefab in the inspector
    public Transform shrimpSpawnPoint; // Assign the spawn point (optional)

    void Update()
    {
        // Handle movement
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Handle shrimp spawning
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnShrimp();
        }
    }

    void SpawnShrimp()
    {
        // If a spawn point is assigned, use its position; otherwise, use the player's position
        Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
        Instantiate(shrimpPrefab, spawnPosition, Quaternion.identity);
    }
}
