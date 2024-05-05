using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.collider.tag == "Player") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.collider.tag != "Shooter") {
            Destroy(gameObject);
        }
    }
}
