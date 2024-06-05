using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenomorphSounds : MonoBehaviour
{
    public AudioClip[] sounds; // Los sonidos que puede emitir el enemigo.
    public AudioClip deathSound;
    public float minTime = 1f; // El tiempo mínimo entre sonidos.
    public float maxTime = 5f; // El tiempo máximo entre sonidos.
    public BossHealthBar bossHealthBar;

    private AudioSource audioSource; // El AudioSource del enemigo.

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource del enemigo.
        StartCoroutine(PlaySounds());
    }

    IEnumerator PlaySounds()
    {
        while (bossHealthBar.currentBossHealth > 0)
        {
            float delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);

            if (bossHealthBar.currentBossHealth == 0)
            {
                break; // Salimos del bucle si la vida del enemigo es 0 o menos.
            }

            int soundIndex = Random.Range(0, sounds.Length);
            audioSource.clip = sounds[soundIndex];
            audioSource.Play();
        }
        
        audioSource.Stop(); // Detiene la reproducción de sonidos aleatorios.
        audioSource.PlayOneShot(deathSound); // Reproduce el sonido de muerte inmediatamente.
    }
}
