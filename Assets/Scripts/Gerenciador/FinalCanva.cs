using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class FinalCanva : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public int currentLevel;

    public Button nextLevelButton;

    public GameObject[] starsImg;

    private int currentStars;
    private int currentCoins;

    public GameObject dubleCoinsButton;

    // text 
    public TextMeshProUGUI levelText;

    public void Start(){
        // set text
        
        currentCoins = PlayerPrefs.GetInt("CurrentCoins", 0);

        pointsText.text = currentCoins.ToString();


        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        levelText.text = "Nível " + currentLevel + "\nconcluído";
        currentStars = PlayerPrefs.GetInt("CurrentStars", 0);
        
        Debug.Log("Current Level: " + currentLevel);
        Debug.Log("Current Stars: " + currentStars);
        
        SetUp(currentStars);
        
        // Zera o número de estrelas coletadas para a próxima fase
        PlayerPrefs.SetInt("CurrentStars", 0);
        PlayerPrefs.Save();
    }

    public void SetUp(int stars){
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

    public void MenuLevel(){
        updateCoins();
        SceneManager.LoadScene("LevelMenu");
    }

    public void NextLevel(){
        Debug.Log(" AAAAAAAAAAAA Trying to load level " + (currentLevel + 1));

        updateCoins();
        SceneManager.LoadScene("jogoFase" + (currentLevel + 1));
    }

    public void RestartLevel(){
        Debug.Log("Trying to Restarti level " + currentLevel);
        updateCoins();
        SceneManager.LoadScene("jogoFase" + currentLevel);
    }

    public void dubleCoins(){
        currentCoins *= 2;
        PlayerPrefs.SetInt("CurrentCoins", currentCoins);
        PlayerPrefs.Save();
        pointsText.text = currentCoins.ToString();
        dubleCoinsButton.SetActive(false);
        dubleCoinsButton.GetComponent<Button>().interactable = false;
    }

    private void updateCoins(){
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoins += currentCoins;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.SetInt("CurrentCoins", 0);
        PlayerPrefs.Save();
        
    }
}
