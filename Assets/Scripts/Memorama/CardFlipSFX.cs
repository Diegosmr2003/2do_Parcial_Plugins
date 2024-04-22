using UnityEngine;

public class CardFlipSFX : MonoBehaviour
{
    [Header("----------Audio Source-----------")]
    [SerializeField] AudioSource efectSource; // Declara una variable de tipo AudioSource.

    [Header("----------Audio Clip-----------")]
    public AudioClip cardFlip; // Declara una variable de tipo AudioClip.


    private void Start()
    {
        efectSource = GetComponent<AudioSource>();
        efectSource.clip = cardFlip; // Se le asigna al AudioSource (musicSource) el AudioClip (background)
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            efectSource.Play(); // Se reproduce la fuente de audio. 
        }
    }
}