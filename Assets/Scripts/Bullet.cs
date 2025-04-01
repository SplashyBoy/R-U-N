using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float bulletSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
