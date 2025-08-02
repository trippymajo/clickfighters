using UnityEngine;

public class UIButtonsSound : MonoBehaviour
{
    public static UIButtonsSound Instance;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }
}