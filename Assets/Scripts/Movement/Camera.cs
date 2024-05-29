using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCamera : MonoBehaviour
{

    Transform player;
    [SerializeField] Vector3 offset;

    public TextMeshProUGUI ovoText;
    public TextMeshProUGUI currentLevelText;

    private string level = "x";

    private bool isFirst = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ovoText.text = PlayerPrefs.GetInt("TotalOvos", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirst){
            isFirst = false;
            level = PlayerPrefs.GetInt("CurrentLevel", 0).ToString();
            currentLevelText.text = level;
        }
        transform.position = player.position + offset;
    }
}
