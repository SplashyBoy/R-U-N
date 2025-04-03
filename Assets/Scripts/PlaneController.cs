using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject platformPrefab; // Reference to the platform prefab
    public Vector3 spawnPositionOffset = new Vector3(0, 0, 10); // Offset for platform spawn position (e.g., based on plane length)
    public float spawnDelay = 2f; // Delay in seconds before spawning (not used in current example, but you can expand it)
    int c = 0; // Just as a placeholder if needed later, remove or modify as needed

    void Start()
    {
        // Initialize or handle any other setup logic here
    }

    void SpawnPlatform(Vector3 planePosition)
    {
        // Calculate the spawn position based on the plane's position and its length (on the Z-axis)
        Vector3 spawnPosition = new Vector3(planePosition.x, planePosition.y, planePosition.z + (transform.localScale.z));

        // Instantiate the platform at the new spawn position
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        // Ensure that the other object has the "Plane" tag before proceeding
        if (other.CompareTag("Plane"))
        {
            // Log the start of the interaction for debugging purposes
            Debug.Log("Trigger detected with Plane object!");

            // Call SpawnPlatform method, passing the plane's position as a parameter
            SpawnPlatform(other.transform.position);
            Debug.Log("Platform hit the limit");

            // Store the reference to the plane object
            GameObject plane = other.gameObject;

            // Log before destroying to help with debugging
            Debug.Log($"Destroying the plane: {plane.name}");

            // Destroy the plane object
            Destroy(plane);

            // Log after destruction to confirm the object has been destroyed
            Debug.Log($"Plane {plane.name} destroyed.");
        }
    }
}