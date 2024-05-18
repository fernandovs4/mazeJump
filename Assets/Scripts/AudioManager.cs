using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(AudioClip clip)
    {
        if (instance != null && instance.audioSource != null)
        {
            instance.audioSource.PlayOneShot(clip);
        }
    }
}
