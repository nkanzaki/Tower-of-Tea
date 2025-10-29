using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource ambientSource;   // birds
    public AudioSource catSource;       // cat meow
    public AudioSource cupSource;       // cup clink

    private bool initialized = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Start silent
        if (ambientSource) ambientSource.Stop();
        if (catSource) catSource.Stop();
        if (cupSource) cupSource.Stop();

        // Prevent auto-play at scene load
        initialized = true;
    }

    public void PlayAmbient()
    {
        if (initialized && ambientSource && !ambientSource.isPlaying)
            ambientSource.Play();
    }

    public void StopAmbient()  { if (ambientSource) ambientSource.Stop(); }
    public void PlayCatSound() { if (initialized && catSource) catSource.PlayOneShot(catSource.clip); }
    public void PlayClink()
{
    if (!initialized || cupSource == null || cupSource.clip == null)
        return;

    var temp = new GameObject("TempClink");
    var s = temp.AddComponent<AudioSource>();

    s.clip = cupSource.clip;
    s.volume = cupSource.volume;
    s.pitch = Random.Range(0.95f, 1.05f);
    s.spatialBlend = 0;
    s.Play();

    Destroy(temp, s.clip.length);
}
}