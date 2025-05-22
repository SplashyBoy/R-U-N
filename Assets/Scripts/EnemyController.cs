using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public Vector3 moveDirection = Vector3.forward;

    [Header("Combat Settings")]
    public int health = 10;
    public int damageToPlayer = 1;

    [Header("Visual Effects")]
    public GameObject deathEffectPrefab;
    public bool rotateToFaceDirection = true;

    [Header("Damage Flash")]
    public float flashDuration = 0.1f; // Duration in seconds (0.1 = 100 milliseconds)

    [Header("References")]
    private Rigidbody rb;
    private Renderer enemyRenderer;
    private Color originalColor;

    // Events
    public event Action OnEnemyDestroyed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }

        // Get the renderer and store original color
        enemyRenderer = GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    void Start()
    {
        if (rotateToFaceDirection && moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    void FixedUpdate()
    {
        // Move forward in the set direction
        rb.velocity = moveDirection * moveSpeed;
    }

    public void Initialize(Vector3 direction, float speed)
    {
        moveDirection = direction.normalized;
        moveSpeed = speed;

        if (rotateToFaceDirection && moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            // Only flash red if enemy survives the damage
            StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
        if (enemyRenderer != null)
        {
            // Change to red
            enemyRenderer.material.color = Color.red;

            // Wait for flash duration
            yield return new WaitForSeconds(flashDuration);

            // Return to original color
            enemyRenderer.material.color = originalColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(1);
        }
    }

    void Die()
    {
        // Trigger death effects
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Invoke the death event
        OnEnemyDestroyed?.Invoke();

        // Destroy the enemy object
        Destroy(gameObject);
    }

    /*  void OnCollisionEnter(Collision collision)
      {
          // Check if collided with player
          if (collision.gameObject.CompareTag("Player"))
          {
              Miranda Miranda = collision.gameObject.GetComponent<Miranda>();
              if (Miranda != null)
              {
                  Miranda.TakeDamage(damageToPlayer);
              }

              // Destroy enemy after hitting player
              Die();
          }
      }*/

    // Useful for visualization in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, moveDirection * 2);
    }
}