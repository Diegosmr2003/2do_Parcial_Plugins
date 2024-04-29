using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Declaramos dos parámetros de tipo SerializeField para poner los audiosource de la música y los efectos de sonido
    [Header("------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    [Header("------------Audio Clip-------------")]
    //public AudioClip background;
    public AudioClip gunshoot; //Pistola dispara
    public AudioClip gunnoammo; //Pistola sin balas
    //public AudioClip chase;
    //public AudioClip nearguardian;

    /*private void Start()
    {
        //musicSource.clip = background;
        //musicSource.Play();
      
    }*/

   
    public void playSFX(AudioClip clip) //Este método es público para que se pueda acceder a él mediante otros scripts
    {
        sfxSource.PlayOneShot(clip); //Le da play al clip puesto como parámetro en la función
    }

    public void stopSFX()
    {
        sfxSource.Stop();
    }

}
