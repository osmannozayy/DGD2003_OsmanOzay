using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int isMuted = PlayerPrefs.GetInt("MusicMuted", 0);
        audioSource.mute = (isMuted == 1);
    }

    public void ToggleMusic()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
            PlayerPrefs.SetInt("MusicMuted", audioSource.mute ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}