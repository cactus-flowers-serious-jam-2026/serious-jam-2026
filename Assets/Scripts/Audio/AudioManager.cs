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
        PlayMusic("bgmusic");
    }


    public void PlayOneShot(string id)
    {
        AudioEntry entry = audioLibrary.Get(id);
        if (entry != null)
        {
            sfxSource.PlayOneShot(entry.audioClip);
        }
    }

    public void PlayMusic(string id)
    {
        AudioEntry entry = audioLibrary.Get(id);
        if (entry != null)
        {
            musicSource.Stop();
            musicSource.clip = entry.audioClip;
            musicSource.loop = true;
            musicSource.Play();
        }

    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    

}
