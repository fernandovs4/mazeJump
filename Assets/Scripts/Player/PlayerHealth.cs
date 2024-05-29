using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public bool escudoAtivo = false;
    public int qtdEscudo;
    public float escudoDuracao = 5f;
    public float escudoCooldown = 10f;

    public float tempoAteMorrer = 1f;
    public bool podeUsarEscudo = true;

    public bool isInvulnerable = false;

    public float invulnerabilityTime = 1f;

    private GameObject player;

    private GameObject escudo;

    
    // Tempo permitido entre cliques para ser considerado um clique duplo
    public float doubleClickTime = 0.15f;
    private float lastClickTime = 0f;

    public float maxClickDistance = 15f; // Maximum distance between two clicks to recognize as a double click

    private Vector2 lastClickPosition;

    // Start is called before the first frame update
    void Start()
    {
        escudo = transform.Find("Escudo").gameObject;
        escudo.SetActive(false);

        qtdEscudo = PlayerPrefs.GetInt("TotalOvos", 0);

        player = GameObject.FindWithTag("Player");
    }


    void Update()
{
        // Detecta toque na tela
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 currentClickPosition = Input.GetTouch(0).position;
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                float distance = Vector2.Distance(currentClickPosition, lastClickPosition);
                if (distance <= maxClickDistance)
                {
                    OnDoubleClick();
                }
            }

            lastClickTime = Time.time;
            lastClickPosition = currentClickPosition;
        }
    }

    // Função chamada no clique duplo
    void OnDoubleClick()
    {
        Debug.Log("Double click detected!");
        if (podeUsarEscudo && qtdEscudo > 0)
        {
            podeUsarEscudo = false;
            qtdEscudo--;
            StartCoroutine(ShieldON());
        }
        // Adicione aqui o que deve acontecer quando o clique duplo é detectado
    }

    private IEnumerator ShieldON(){
        escudoAtivo = true;
        escudo.SetActive(true);

        yield return new WaitForSeconds(escudoDuracao);
        escudoAtivo = false;
        escudo.SetActive(false);

        StartCoroutine(ShieldCooldown());
    }

    public void PlayerHit(){
        
        if(escudoAtivo){
            escudoAtivo = false;
            escudo.SetActive(false);
            StartCoroutine(Invulnerability());
            podeUsarEscudo = false;
            StartCoroutine(ShieldCooldown());
        }else{
            if(isInvulnerable){
                return;
            }
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator Invulnerability(){
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime);
        isInvulnerable = false;
    }

    IEnumerator ShieldCooldown(){
        yield return new WaitForSeconds(escudoCooldown);
        podeUsarEscudo = true;
    }

    IEnumerator DeathCoroutine(){
        yield return new WaitForSeconds(tempoAteMorrer);
        Destroy(player);
        PlayerPrefs.SetInt("TotalOvos", qtdEscudo);
        PlayerPrefs.Save();
        // Adicione aqui o que deve acontecer quando o jogador morre
        SceneManager.LoadScene("Derrota");
    }
}
