using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ExpadingBall : MonoBehaviour
{

    [SerializeField] float timeUnExpanded, timeExpanded;
    [SerializeField] GameObject ballSpike;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExpansionCycle());
    }

    IEnumerator ExpansionCycle(){
        Object[] spikes = new Object[8];

        while (true) {
            yield return new WaitForSeconds(timeUnExpanded);
            count = 0;
            for (int i = -1; i < 2; i++) {
                for (int j = -1; j < 2; j++) {
                    if (i == 0 && j == 0) {
                        continue;
                    }
                    spikes[count] = Instantiate(ballSpike, transform.position + new Vector3(i, j, 0), Quaternion.identity);
                    count++;
                }
            }
            yield return new WaitForSeconds(timeExpanded);
            for (int i = 0; i < 8; i++) {
                Destroy(spikes[i]);
            }
            
        }

    }

}
