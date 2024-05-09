using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
       // Start is called before the first frame update
    [SerializeField] float countDown;
    List <Direction> dirOfTouch = new List<Direction>();
    [SerializeField] LayerMask playerMask;
   public void startCountDown(){
    if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 0.6f, playerMask)) dirOfTouch.Add(Direction.North);
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up), Color.green, 0.6f);
    if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 0.6f, playerMask)) dirOfTouch.Add(Direction.South);
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down), Color.green, 0.6f);
    if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.6f, playerMask)) dirOfTouch.Add(Direction.West);
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left), Color.green, 0.6f);
    if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.6f, playerMask))  dirOfTouch.Add(Direction.East);
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right), Color.green, 0.6f);
    
    StartCoroutine(KillPlayer(countDown));
   }

    IEnumerator KillPlayer(float waitTime){
        yield return new WaitForSeconds(waitTime);

        foreach (Direction dir in dirOfTouch){
            if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 0.6f, playerMask) && dir == Direction.North ) Destroy(GameObject.Find("Player"));
            else if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 0.6f, playerMask) && dir == Direction.South) Destroy(GameObject.Find("Player"));
            else if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.6f, playerMask) && dir == Direction.West) Destroy(GameObject.Find("Player"));
            else if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.6f, playerMask) && dir == Direction.East)  Destroy(GameObject.Find("Player"));
        }

           
    
    }
}
