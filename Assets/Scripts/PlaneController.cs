using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public GameObject planePrefab; // Reference to the plane prefab
    public GameObject planeB; // Reference to the second plane (PlaneB)
    public Transform limit; // Reference to the Limit object (empty GameObject with Box Collider)

    private Vector3 spawnPosition = new Vector3(0, -1, 12.18293f); // Position for new planes

    // When any of the planes touches the Limit's collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane") || other.gameObject.CompareTag("PlaneB"))
        {
            // Check which plane hit the limit and destroy it
            Destroy(other.gameObject);

            // Instantiate a new plane at the spawn position
            Instantiate(planePrefab, spawnPosition, Quaternion.identity);
        }
    }
}