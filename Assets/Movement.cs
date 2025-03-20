using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 7f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mirinda a inceput");
    }

    void Update()
    {
        // Get horizontal input (A/D keys or left/right arrow keys)
        float moveInput = Input.GetAxis("Horizontal");

        // Move the object along the X axis

        rb.MovePosition(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
    }
}
