using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] Direction pointingDirection;
    [SerializeField] float projectVelocity, timeBetweenShot;
    [SerializeField] GameObject projectile;

    void Start() {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        GameObject go = new GameObject();

        while (true) {
            yield return new WaitForSeconds(timeBetweenShot);

            switch(pointingDirection){
                case Direction.North:
                    go = Instantiate(projectile, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectVelocity);
                    break;
                case Direction.South:
                    go = Instantiate(projectile, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectVelocity);
                    break;
                case Direction.East:
                    go = Instantiate(projectile, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(projectVelocity, 0);
                    break;
                case Direction.West:
                    go = Instantiate(projectile, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectVelocity, 0);
                    break;
                default:
                    break;
            }
        }
    }
}
