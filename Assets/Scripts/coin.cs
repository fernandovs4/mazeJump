using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip coinSound; // Atribua o áudio da moeda pelo Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Encontra o AudioSource no objeto global (AudioManager)
        audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroi a moeda imediatamente
            Debug.Log("Player colidiu com a moeda!");
            audioSource.PlayOneShot(coinSound); // Reproduz o som sem interromper sons anteriores
            
            // salva o número de moedas coletadas na fase
            int currentCoins = PlayerPrefs.GetInt("CurrentCoins", 0);
            currentCoins++;
            PlayerPrefs.SetInt("CurrentCoins", currentCoins);
            PlayerPrefs.Save();
        }
    }
}
