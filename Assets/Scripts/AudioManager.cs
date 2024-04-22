using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Source-------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------Audio Clip-------------")]
    public AudioClip background;
    public AudioClip gunshoot;
    public AudioClip gunnoammo;
    public AudioClip chase;
    public AudioClip nearguardian;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip) //Este m�todo es p�blico para que se pueda acceder a �l mediante otros scripts
    {
        sfxSource.PlayOneShot(clip);
    }

    public void stopSFX()
    {
        sfxSource.Stop();
    }

}
