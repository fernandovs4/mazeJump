using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{

    public void Start(){
        PlayerPrefs.SetInt("CurrentCoins", 0);
        PlayerPrefs.Save();
    }
    public void MenuLevel(){
        SceneManager.LoadScene("LevelMenu");
    }


    public void RestartLevel(){
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        SceneManager.LoadScene("jogoFase" + currentLevel);
    }
}
