using UnityEngine;

public class Estrelinha : MonoBehaviour
{
    private PhaseControlls phaseControlls;
    private int faseAtual;

    void Start()
    {
        phaseControlls = FindObjectOfType<PhaseControlls>();
        faseAtual = phaseControlls.faseAtual;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Estrela coletada!");
            // Incrementa o número de estrelas coletadas
            int currentStars = PlayerPrefs.GetInt("CurrentStars", 0);
            currentStars++;
            PlayerPrefs.SetInt("CurrentStars", currentStars);
            PlayerPrefs.Save();

            // Destrói a estrela para simular a coleta
            Destroy(gameObject);
        }
    }
}
