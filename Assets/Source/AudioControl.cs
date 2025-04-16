using UnityEngine;

public enum SoundType
{
    Gaining,
    Losing,
    Reset
}

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;

    private static AudioControl instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}
