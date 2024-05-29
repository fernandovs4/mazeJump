using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{

    public TextMeshProUGUI textCoins;
    public TextMeshProUGUI textOvos;

    public GameObject canvasShop;

    public GameObject dinheiroSuficiente;

    public GameObject ovosButton;

    private int totalOvos;
    private int coins;


    public void Awake(){
        totalOvos = PlayerPrefs.GetInt("TotalOvos", 0);
        textOvos.text = totalOvos.ToString();

        coins = PlayerPrefs.GetInt("TotalCoins", 0);
        textCoins.text = CoinsinText(coins.ToString());
    }

    public void OpenLevel(int levelId){
        string levelName = "jogoFase" + (levelId-1);
        SceneManager.LoadScene(levelName);
    }

    public void OpenShop(){
        canvasShop.SetActive(true);
        if (coins >= 100) {
            ovosButton.SetActive(true);
            dinheiroSuficiente.SetActive(false);
        } else {
            ovosButton.SetActive(false);
            dinheiroSuficiente.SetActive(true);
        }
    }

    public void BuyOvos(){
        if (coins >= 100) {
            coins -= 100;
            totalOvos += 1;
            PlayerPrefs.SetInt("TotalOvos", totalOvos);
            PlayerPrefs.SetInt("TotalCoins", coins);
            PlayerPrefs.Save();
            textOvos.text = totalOvos.ToString();
            textCoins.text = CoinsinText(coins.ToString());
        } else {
            dinheiroSuficiente.SetActive(true);
        }
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
