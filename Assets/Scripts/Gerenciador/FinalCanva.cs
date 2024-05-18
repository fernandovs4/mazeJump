using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class FinalCanva : MonoBehaviour
{
    // public TextMeshProUGUI pointsText;
    public int currentLevel;

    public Button nextLevelButton;

    public GameObject[] starsImg;

    private int currentStars;

    public void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        currentStars = PlayerPrefs.GetInt("CurrentStars", 0);
        
        Debug.Log("Current Level: " + currentLevel);
        Debug.Log("Current Stars: " + currentStars);
        
        SetUp(currentStars);
        
        // Zera o número de estrelas coletadas para a próxima fase
        PlayerPrefs.SetInt("CurrentStars", 0);
        PlayerPrefs.Save();
    }

    public void SetUp(int stars)
    {
        gameObject.SetActive(true);

        for (int i = 0; i < starsImg.Length; i++)
        {
            if (i < stars)
            {
                starsImg[i].SetActive(true);
            }
            else
            {
                starsImg[i].SetActive(false);
            }
        }
    }

    public void MenuLevel()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void NextLevel()
    {
        Debug.Log(" AAAAAAAAAAAA Trying to load level " + (currentLevel + 1));


        SceneManager.LoadScene("jogoFase" + (currentLevel + 1));
    }

    public void RestartLevel()
    {
        Debug.Log("Trying to Restarti level " + currentLevel);
        SceneManager.LoadScene("jogoFase" + currentLevel);
    }
}
