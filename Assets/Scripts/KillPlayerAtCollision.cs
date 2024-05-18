using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerAtCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Destroy(other.gameObject);
        }
    }
}
