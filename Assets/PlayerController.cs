using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{   


    public GameObject shrimpPrefab; // Reference to the shrimp prefab
    public GameObject TempuraPrefab;

    public GameObject ShahsimiPrefab;

    public GameObject CA_RollPrefab;

    public GameObject NigriPrefab;

    public GameObject MakiPrefab;

    public GameObject GunkanPrefab;

    public GameObject TemakiPrefab;

    public float moveSpeed = 5f; // Speed at which the rectangle moves
                                         // Assign the Shrimp prefab in the inspector
    public Transform shrimpSpawnPoint;
    public float spawnCooldown = 1f;
    private float nextSpawnTime = 0f;
    public int playerScore;
    public Vector3 playerPosition; 
     private List<GameObject> prefabs;


 


     void Start()
    {
        // Initialize the list of prefabs
        prefabs = new List<GameObject> { shrimpPrefab, TempuraPrefab, ShahsimiPrefab, CA_RollPrefab, NigriPrefab, MakiPrefab};
    }



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
        
            SceneManager.LoadScene("TitleScreen");
            
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawnTime)
        {
            SpawnRandomItem();
            nextSpawnTime = Time.time + spawnCooldown;
        }

   
    }



   void SpawnTempura()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(TempuraPrefab, spawnPosition, Quaternion.identity);
   }
   

    void SpawnShrimp()
    {
        // If a spawn point is assigned, use its position; otherwise, use the player's position
        Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
        Instantiate(shrimpPrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnShashimi()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(ShahsimiPrefab, spawnPosition, Quaternion.identity);
   }

    void SpawnCA_Roll()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(CA_RollPrefab, spawnPosition, Quaternion.identity);
   }

      void SpawnNigri()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(NigriPrefab, spawnPosition, Quaternion.identity);
   }
    

    void SpawnMaki()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(MakiPrefab, spawnPosition, Quaternion.identity);
   }


    void SpawnGunkan()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(GunkanPrefab, spawnPosition, Quaternion.identity);
   }

    void SpawnTemaki()
   {

    Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
    Instantiate(TemakiPrefab, spawnPosition, Quaternion.identity);
   }



    void SpawnRandomItem()
    {
        // Choose a random prefab from the list
        int randomIndex = Random.Range(0, prefabs.Count);
        GameObject prefabToSpawn = prefabs[randomIndex];

        // If a spawn point is assigned, use its position; otherwise, use the player's position
        Vector3 spawnPosition = shrimpSpawnPoint != null ? shrimpSpawnPoint.position : transform.position;
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }



}
