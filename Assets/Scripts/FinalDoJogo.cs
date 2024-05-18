using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoJogo : MonoBehaviour
{
    private PhaseControlls phaseControlls;
    private int faseAtual;

    void Start()
    {
        phaseControlls = FindObjectOfType<PhaseControlls>();
        faseAtual = phaseControlls.faseAtual;
        PlayerPrefs.SetInt("CurrentLevel", faseAtual);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Pega o número de estrelas coletadas nesta fase
            int currentStars = PlayerPrefs.GetInt("CurrentStars", 0);

            // Carrega o número de estrelas salvo anteriormente para esta fase
            int estrelasSalvas = PlayerPrefs.GetInt("Stars_Level_" + faseAtual, 0);

            Debug.Log("Estrelas coletadas: " + currentStars);
            Debug.Log("Estrelas salvas: " + estrelasSalvas);
            Debug.Log("Fase atual: " + faseAtual);


            // Se o número de estrelas coletadas for maior, salve o novo valor
            if (currentStars > estrelasSalvas)
            {
                PlayerPrefs.SetInt("Stars_Level_" + faseAtual, currentStars);
                PlayerPrefs.Save();
            }

            // verificar se é a ultima fase e aumentar o numero de fases liberadas
            if ( faseAtual == PlayerPrefs.GetInt("levelReached", 1) )
            {
                PlayerPrefs.SetInt("levelReached", faseAtual + 1);
                PlayerPrefs.Save();
            }
            // Direciona para a tela de fim de jogo
            SceneManager.LoadScene("Victory");
        }
    }
}
