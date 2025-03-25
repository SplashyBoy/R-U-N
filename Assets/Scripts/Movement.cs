using UnityEngine;


public class Movement : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody
    public float moveSpeed = 5f; // Speed of the movement

    void FixedUpdate()
    {
        // Get input from the user (horizontal axis)
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;

        // Set the velocity for movement on the X-axis only
        rb.velocity = new Vector3(moveX, rb.velocity.y, 0);
    }
}