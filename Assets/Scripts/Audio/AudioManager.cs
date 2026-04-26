using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] private AudioLibrary audioLibrary;
    
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    
    

    private void Awake()
    {
        if (Instance != null &&  Instance != this)
        {
            Debug.LogWarning("Multiple AudioManagers found!");
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        PlayMusic();
    }


    public void PlayOneShot(string id)
    {
        AudioEntry entry = audioLibrary.Get(id);
        if (entry != null)
        {
            sfxSource.PlayOneShot(entry.audioClip);
        }
    }

    private void PlayMusic()
    {
        AudioEntry entry = audioLibrary.Get("bgmusic");
        if (entry != null)
        {
            musicSource.clip = entry.audioClip;
            musicSource.loop = true;
            musicSource.Play();
        }

    }
    

}
