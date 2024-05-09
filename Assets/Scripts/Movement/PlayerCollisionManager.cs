using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
   PlayerMovement player;
   RaycastHit2D hit;
   [SerializeField] LayerMask obstacleMask;
   [SerializeField] float timeAfterSpikesKill;

 

   void Start()
   {
       
        player = GetComponent<PlayerMovement>();
       
   }

   void OnCollisionEnter2D(Collision2D info ){
    if (info.collider.tag == "Spikes"){
         if (player == null) {
        Debug.LogError("Player is null!");
        return;
    }
        Debug.Log("Hit Spikes");
        switch (player.movingDir){
            case Direction.North:
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, obstacleMask);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up), Color.green, 1);
                break;
            case Direction.South:
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1, obstacleMask);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down), Color.green, 1);
                break;
            case Direction.East:
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1, obstacleMask);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right), Color.green, 1);
                break;
            case Direction.West:
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1, obstacleMask);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left), Color.green, 1);
                break;
        }
          if (hit != null){
                    Destroy(GameObject.Find("Player"));
                } 
    }

    if (info.collider.tag == "SpikesAfterTime"){
        info.collider.GetComponent<SpikesAfterTime>().startCountDown();
    }
   
   }
  
}
