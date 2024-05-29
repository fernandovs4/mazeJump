using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.collider.tag == "Player") {
            other.gameObject.GetComponent<PlayerHealth>().PlayerHit();
            Destroy(gameObject);
        }

        if(other.collider.tag != "Shooter") {
            Destroy(gameObject);
        }
    }
}
