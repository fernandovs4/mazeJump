using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    North, South, East, West
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] bool movingHorizontally = false, canCheck = true;
    public float speed;

    Rigidbody2D rb;

    private bool isMoving = false;
    private Vector2 moveDirection = Vector2.zero;

    public Direction movingDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            movingDir = Direction.North;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            movingDir = Direction.South;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            movingDir = Direction.West;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            movingDir = Direction.East;
        }

        if (direction != Vector2.zero)
        {
            if (canCheck)
            {
                isMoving = true;
                moveDirection = direction.normalized * speed * Time.deltaTime;

                // Check for obstacles in the direction of movement
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.0f, obstacleMask);
                if (hit.collider != null)
                {
                    isMoving = false;
                    moveDirection = Vector2.zero;
                }
            }
        }
        else
        {
            isMoving = false;
            moveDirection = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.MovePosition(rb.position + moveDirection);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with wall.");
        if (obstacleMask == (obstacleMask | (1 << collision.gameObject.layer)))
        {
            Debug.Log("Player collided with wall, vibration triggered.");
            TriggerVibration();
        }
    }

    void TriggerVibration()
    {
#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
#endif
    }
}