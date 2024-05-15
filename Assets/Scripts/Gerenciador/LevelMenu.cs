using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

    public Button[] buttons;

    public void Awake(){
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i < buttons.Length; i++){
            if(i + 1 > levelReached){
                buttons[i].interactable = false;
            }
        }
    }

    public void OpenLevel(int levelId){
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
