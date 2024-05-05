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
    [SerializeField]  bool movingHorizontally = false, canCheck = true;
    public float speed;
    Rigidbody2D rb;
 
  

    public Direction movingDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingHorizontally){
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1, obstacleMask)){
                canCheck = true;
            }
            else{
                canCheck = false;
            }
        }
        else{
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, obstacleMask) || Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1, obstacleMask)){
                canCheck = true;
            }
            else{
                canCheck = false;
            }
        }

    

        

        if (canCheck){
            if (Input.GetAxisRaw("Horizontal") != 0){
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            movingHorizontally = true;
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                movingDir = Direction.East;
            }
            else
            {
                movingDir = Direction.West;
            }
        }
        else if (Input.GetAxisRaw("Vertical") != 0){
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation ;
            movingHorizontally = false;
             if (Input.GetAxisRaw("Vertical") > 0)
            {
                movingDir = Direction.North;
            }
            else
            {
                movingDir = Direction.South;
            }
        }
            
        }
        
        
    }

    void FixedUpdate(){
        switch (movingDir)
        {
            case Direction.North:
                rb.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                break;
            case Direction.South:
                rb.velocity = new Vector2(0, -speed*Time.fixedDeltaTime);
                break;
            case Direction.East:
                rb.velocity = new Vector2(speed*Time.fixedDeltaTime, 0);
                break;
            case Direction.West:
                rb.velocity = new Vector2(-speed*Time.fixedDeltaTime, 0);
                break;
        }
    }
}
