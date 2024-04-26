using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSFX : MonoBehaviour
{
    public Transform player; // Referencia al jugador 
    public AudioClip backgroundMusic; // Música de fondo
    public AudioClip approachMusic;
    public AudioClip chaseMusic;

    private AudioSource audioSource;
    private bool isChasing = false;

    GuardianScript persecucion;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        persecucion = GetComponent<GuardianScript>();
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        StartCoroutine(CheckPlayerDistance());
    }

    IEnumerator CheckPlayerDistance()
    {
        while (true)
        {
            while (true)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                if (distanceToPlayer < 7f && distanceToPlayer > 1f /*&& !isChasing*/)
                {
                    ChangeMusic(approachMusic);
                }
                else if (distanceToPlayer >= 10f)
                {
                    ChangeMusic(backgroundMusic);
                }
                else if (persecucion.following)
                {
                    ChangeMusic(chaseMusic);
                }

                yield return new WaitForSeconds(1f); // Comprueba la distancia cada segundo
            }
        }
    }

    void ChangeMusic(AudioClip newClip)
    {
        if (audioSource.clip != newClip)
        {
            audioSource.Stop();
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}