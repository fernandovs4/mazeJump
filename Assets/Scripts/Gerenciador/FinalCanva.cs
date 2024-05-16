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


    public void SetUp(int stars){
        gameObject.SetActive(true);


        for (int i = 0; i < 3; i++){
            if (i < stars){
                starsImg[i].SetActive(true);
            } else {
                starsImg[i].SetActive(false);
            }
        }
    }

    public void MenuLevel(){
        SceneManager.LoadScene("LevelMenu");
    }
    public void NextLevel(){
        SceneManager.LoadScene("Level " + (currentLevel + 1));
    }


    public void RestartLevel(){
        SceneManager.LoadScene("Level " + currentLevel);
    }




}
