using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenouraController : MonoBehaviour
{
   private float tempoAteACenouraEstarAtiva;
    private float tempoParaDesativarCenoura;

    private PhaseControlls phaseControlls;

    private bool canBeActivated;

    public Animator cenouraAnimator;
    // Start is called before the first frame update
    private bool playerInRange;

    private GameObject player;

    private bool cenouraEstaAtiva;

    private void Start()
    {
        cenouraAnimator = GetComponent<Animator>();
        cenouraAnimator.SetBool("Cenoura_ativa", false);     
        phaseControlls = FindObjectOfType<PhaseControlls>();
        tempoAteACenouraEstarAtiva = phaseControlls.tempoAteACenouraEstarAtiva;
        tempoParaDesativarCenoura = phaseControlls.tempoParaDesativarCenoura;
        canBeActivated = true;
        playerInRange = false;
        player = GameObject.FindWithTag("Player");
        cenouraEstaAtiva = false;
    }

    private void Update() {
        if (cenouraEstaAtiva && playerInRange){
            Destroy(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            playerInRange = true;
            if (canBeActivated){
                canBeActivated = false;
                StartCoroutine(AtivarCenoura());
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            playerInRange = false;
        }
        
    }

    IEnumerator AtivarCenoura(){
        Debug.Log("Entrou na rotina de ativar cenoura");
        cenouraAnimator.SetBool("Cenoura_ativa", true);
        yield return new WaitForSeconds(tempoAteACenouraEstarAtiva);
        cenouraEstaAtiva = true;
        StartCoroutine(DesativarCenoura());
    }

    IEnumerator DesativarCenoura(){
        Debug.Log("Entrou na rotina de desativar cenoura");
        yield return new WaitForSeconds(tempoParaDesativarCenoura);
        cenouraAnimator.SetBool("Cenoura_ativa", false);
        cenouraEstaAtiva = false;
        canBeActivated = true;                  
    }                     
                       
}
