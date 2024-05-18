using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeMortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.gameObject.GetComponent<Player>().Morrer();
            Destroy(collision.gameObject);
        }
    }
}
