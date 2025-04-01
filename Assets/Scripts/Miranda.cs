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
        bulletPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Bullet.prefab");
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector3(moveX, rb.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }


    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}