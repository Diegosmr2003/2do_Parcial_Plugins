using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [Header("----------Audio Source-----------")]
    [SerializeField] AudioSource musicSource; // Declara una variable de tipo AudioSource.

    [Header("----------Audio Clip-----------")]
    public AudioClip background; // Declara una variable de tipo AudioClip.


    private void Start()
    {
        musicSource.clip = background; // Se le asigna al AudioSource (musicSource) el AudioClip (background)
        musicSource.Play(); // Se reproduce la fuente de audio. 
    }
}