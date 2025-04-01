using UnityEngine;
using UnityEditor;


public class Miranda : MonoBehaviour
{
    private GameObject bulletPrefab;
    private Rigidbody rb;
    private float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/YourPrefabName.prefab");
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector3(moveX, rb.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }


    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
    }
}