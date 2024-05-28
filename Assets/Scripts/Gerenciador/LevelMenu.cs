using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{

    public TextMeshProUGUI textCoins;
    public GameObject canvasShop;


    public void Awake(){

        // string coins = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
        // textCoins.text = CoinsinText(coins);
    }

    public void OpenLevel(int levelId){
        string levelName = "jogoFase" + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void OpenShop(){
        canvasShop.SetActive(true);
    }

    public void CloseShop(){
        canvasShop.SetActive(false);
    }

    
    private string CoinsinText(string numberStr) {
        long.TryParse(numberStr, out long number);
        string abbreviated;
        if (number >= 1_000_000_000)
        {
            abbreviated = (number / 1_000_000_000.0).ToString("0.0") + "B";
        }
        else if (number >= 1_000_000)
        {
            abbreviated = (number / 1_000_000.0).ToString("0.0") + "M";
        }
        else if (number >= 1_000)
        {
            abbreviated = (number / 1_000.0).ToString("0.0") + "k";
        }
        else
        {
            abbreviated = number.ToString();
        }

        // Remove the trailing ".0" if it exists
        if (abbreviated.EndsWith(".0"))
        {
            abbreviated = abbreviated.Substring(0, abbreviated.Length - 2);
        }

        return abbreviated;
    }
}
