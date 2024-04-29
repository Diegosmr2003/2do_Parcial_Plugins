using UnityEngine;

public class CardFlipSFX : MonoBehaviour
{
    [Header("----------Audio Source-----------")]   // Atributo que se utiliza para agregar un encabezado en el inspector de Unity.
    [SerializeField]    // Atributo permite que esta variable privada sea visible y editable desde el inspector de Unity.
    AudioSource effectSource;    // Declaramos una variable de tipo AudioSource. 

    [Header("----------Audio Clip-----------")]
    public AudioClip cardFlip;    // Declaramos una variable de tipo AudioClip.


    private void Start()
    {
        effectSource = GetComponent<AudioSource>();    // Aqu� estamos obteniendo el componente AudioSource del objeto de juego al que est� adjunto este script y lo asignamos a effectSource.
        effectSource.clip = cardFlip;    // Aqu� estamos asignando el AudioClip cardFlip a la propiedad clip del AudioSource effectSource.
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))   // Aqu� estamos comprobando si el bot�n izquierdo del rat�n ha sido pulsado durante el �ltimo frame.
        {
            effectSource.Play(); // Se reproduce la fuente de audio. 
        }
    }
}