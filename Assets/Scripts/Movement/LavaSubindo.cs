using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSubindo : MonoBehaviour
{
    public float velocidade = 1f;

    void Update()
    {
        transform.Translate(Vector3.up * velocidade * Time.deltaTime);
    }

    
}
