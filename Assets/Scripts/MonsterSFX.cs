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

    GameObject availableGuardians;

    CameraChange camera;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        persecucion = GetComponent<GuardianScript>();
        audioSource.clip = backgroundMusic;
        audioSource.Play();
        StartCoroutine(CheckPlayerDistance());
        availableGuardians = GameObject.Find("GuardianBox");

        camera = GetComponent<CameraChange>();

    }

    IEnumerator CheckPlayerDistance()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < 12f && distanceToPlayer > 1f && !persecucion.following)
            {
                
                ChangeMusic(approachMusic);
            }
            else if (distanceToPlayer >= 12f)
            {
                
                ChangeMusic(backgroundMusic);
            }
            else if (persecucion.following)
            {
                persecucion.following = false;
                ChangeMusic(chaseMusic);
            }
            yield return new WaitForSeconds(1f); // Comprueba la distancia cada segundo 
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

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 12f && Vector3.Distance(transform.position, player.position) > 1f)
        {
            camera.activateEffect();
        }
        else if (Vector3.Distance(transform.position, player.position) >= 12f)
        {
            camera.deactivateEffect();
        }
    }
    /*
    private void OnDestroy()
    {
        if (camera != null)
        {
            camera.deactivateEffect();
        }
    }
    */
    

}