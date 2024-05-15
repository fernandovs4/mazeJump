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


    public void Setup(int score, int stars, bool isVictory){
        // gameObject.SetActive(true);
        // pointsText.text = score.ToString() ;
        // if (isVictory){
        //     nextLevelButton.interactable = true;
        // } else {
        //     nextLevelButton.interactable = false;
        // }

        // for (int i = 0; i < 3; i++){
        //     if (i < stars){
        //         starsImg[i].SetActive(true);
        //     } else {
        //         starsImg[i].SetActive(false);
        //     }
        // }
    }

    public void MenuLevel(){
        SceneManager.LoadScene("LevelMenu");
    }
    public void NextLevel(){
        SceneManager.LoadScene("Level " + (currentLevel + 1));
    }


    public void RestartButton(){
        SceneManager.LoadScene("Level " + currentLevel);
    }




}
