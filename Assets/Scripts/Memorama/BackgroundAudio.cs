using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [Header("----------Audio Source-----------")]   // Atributo que se utiliza para agregar un encabezado en el inspector de Unity.
    
    [SerializeField]    // Atributo permite que esta variable privada sea visible y editable desde el inspector de Unity.
    AudioSource musicSource;   // Declaramos una variable de tipo AudioSource. 

    [Header("----------Audio Clip-----------")]
    public AudioClip background;    // Declaramos una variable de tipo AudioClip.


    private void Start()
    {
        musicSource.clip = background;    // Aqu� estamos asignando el AudioClip background a la propiedad clip del AudioSource musicSource.
        musicSource.Play();    // Aqu� estamos llamando al m�todo Play del AudioSource musicSource.
    }
}