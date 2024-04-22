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

    public void playSFX(AudioClip clip) //Este método es público para que se pueda acceder a él mediante otros scripts
    {
        sfxSource.PlayOneShot(clip);
    }

    public void stopSFX()
    {
        sfxSource.Stop();
    }

}
