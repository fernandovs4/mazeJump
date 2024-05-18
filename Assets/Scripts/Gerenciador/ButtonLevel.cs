using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class ButtonLevel : MonoBehaviour
{
    public int levelId;
    public GameObject desbloqueado;
    public GameObject bloqueado;

    public TextMeshProUGUI levelText;

    public GameObject[] starsImg;

    private int levelStars;


    public void Awake()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", PlayerPrefs.GetInt("levelReached", 1));
        int levelStars = PlayerPrefs.GetInt("Stars_Level_" + levelId, 0);


        if (levelId > levelReached){
            desbloqueado.SetActive(false);
            bloqueado.SetActive(true);
        } else {
            desbloqueado.SetActive(true);
            bloqueado.SetActive(false);
        }

        SetUp(levelStars);

        levelText.text = levelId.ToString();
    }

    public void SetUp(int stars)
    {
        gameObject.SetActive(true);

        for (int i = 0; i < starsImg.Length; i++)
        {
            if (i < stars)
            {
                starsImg[i].SetActive(true);
                Debug.Log("Star " + (i + 1) + " set to active");
            }
            else
            {
                starsImg[i].SetActive(false);
                Debug.Log("Star " + (i + 1) + " set to inactive");
            }
        }
    }

    public void OpenLevel()
    {
        string levelName = "jogoFase" + levelId;
        SceneManager.LoadScene(levelName);
    }
}
