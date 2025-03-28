using UnityEngine;
using Unity.Asse


public class Miranda : MonoBehaviour
{
    private GameObject bulletPrefab;
    private Rigidbody rb; // Reference to the Rigidbody
    private float moveSpeed = 5f; // Speed of the movement

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/YourPrefabName.prefab");
    }

    void FixedUpdate()
    {
        // Get input from the user (horizontal axis)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;

        // Set the velocity for movement on the X-axis only
        rb.velocity = new Vector3(moveX, rb.velocity.y, 0);


    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
    }
}