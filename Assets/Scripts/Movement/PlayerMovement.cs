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

    private Vector2 startTouchPosition;
    private bool swipeRegistered = false;

    public Direction movingDir;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity == Vector2.zero) // Only allow new movement if the player is not moving
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startTouchPosition = touch.position;
                        swipeRegistered = false;
                        break;

                    case TouchPhase.Moved:
                        if (!swipeRegistered) // Check if swipe direction is not yet registered
                        {
                            Vector2 touchEndPosition = touch.position;
                            Vector2 direction = touchEndPosition - startTouchPosition;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // Horizontal swipe
                                movingHorizontally = true;
                                canCheck = !Physics2D.Raycast(transform.position, direction.x > 0 ? Vector2.right : Vector2.left, 1.0f, obstacleMask);
                                movingDir = direction.x > 0 ? Direction.East : Direction.West;
                            }
                            else
                            {
                                // Vertical swipe
                                movingHorizontally = false;
                                canCheck = !Physics2D.Raycast(transform.position, direction.y > 0 ? Vector2.up : Vector2.down, 1.0f, obstacleMask);
                                movingDir = direction.y > 0 ? Direction.North : Direction.South;
                            }

                            swipeRegistered = true; // Mark swipe as registered
                        }
                        break;
                }
            }

            // Apply constraints based on swipe direction
            if (canCheck)
            {
                if (movingHorizontally)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                }
            }
            else
            {
                // Free all constraints if movement is not allowed
                rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    void FixedUpdate()
    {
        if (canCheck && rb.velocity == Vector2.zero) // Only move if canCheck is true and velocity is zero
        {
            Vector2 moveDirection = Vector2.zero;
            switch (movingDir)
            {
                case Direction.North:
                    moveDirection = new Vector2(0, speed * Time.fixedDeltaTime);
                    break;
                case Direction.South:
                    moveDirection = new Vector2(0, -speed * Time.fixedDeltaTime);
                    break;
                case Direction.East:
                    moveDirection = new Vector2(speed * Time.fixedDeltaTime, 0);
                    break;
                case Direction.West:
                    moveDirection = new Vector2(-speed * Time.fixedDeltaTime, 0);
                    break;
            }
            rb.velocity = moveDirection;
        }
    }
}
