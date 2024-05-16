using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;        // Movement speed
    public float rayLength = 0.1f;  // Length of the raycast
    public LayerMask obstacleLayer; // Layer for obstacles
    public LayerMask invisibleLayer; // Layer for invisible objects

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        CheckForCollision();
    }

    void Move()
    {
        rb.velocity = new Vector2(movementDirection.x * speed, rb.velocity.y);
    }

    void CheckForCollision()
    {
        Vector2 rayOrigin = transform.position;
        LayerMask combinedLayerMask = obstacleLayer | invisibleLayer;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, movementDirection, rayLength, combinedLayerMask);

        if (hit.collider != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        movementDirection = -movementDirection;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 rayOrigin = transform.position;
        Gizmos.DrawLine(rayOrigin, rayOrigin + movementDirection * rayLength);
    }
}
