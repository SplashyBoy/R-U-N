using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject platformPrefab; // Reference to the platform prefab
    public Vector3 spawnPosition = new Vector3(0, 5, 0); // Default spawn position
    public float spawnDelay = 2f; // Delay in seconds before spawning
    
    void Start()
    {
        // Start spawning platforms after a delay
        InvokeRepeating("SpawnPlatform", 0f, spawnDelay);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Debug.Log("Platform hit the limit");

            // Destroy the platform upon collision with the player
            Destroy(gameObject);
        }
    }
        void SpawnPlatform()
    {
        // Instantiate a platform at the specified spawn position
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Debug.Log("Triggered with limit! Destroying object.");
            Destroy(gameObject);
        }
    }
}