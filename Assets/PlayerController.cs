using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{   


     public GameObject shrimpPrefab; // Reference to the shrimp prefab
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
        // Get horizontal input
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Apply movement
        transform.Translate(movement);


 

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



   
   

    void SpawnShrimp()
    {
        // If a spawn point is assigned, use its position; otherwise, use the player's position
        Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
        Instantiate(shrimpPrefab, spawnPosition, Quaternion.identity);
    }


}
