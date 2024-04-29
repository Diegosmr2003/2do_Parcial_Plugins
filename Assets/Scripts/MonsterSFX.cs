using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSFX : MonoBehaviour
{
    public Transform player;    // Referencia al jugador.
    public AudioClip backgroundMusic;    // M�sica de fondo.
    public AudioClip approachMusic;    // M�sica cuando el monstruo se acerca al jugador. 
    public AudioClip chaseMusic;    // M�sica cuando el monstruo detecta y persigue al jugador.

    private AudioSource audioSource;    // Fuente de audio para reproducir la m�sica.

    GuardianScript persecucion;    // Script del guardi�n que controla la persecuci�n.

    GameObject availableGuardians;    // Objeto que contiene a los guardianes disponibles.

    CameraChange cameraFx;    // Efectos de c�mara.

    private bool detected;     // Variable para controlar si el jugador ha sido detectado.

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();    // Obtiene el componente AudioSource del objeto de juego.
        persecucion = GetComponent<GuardianScript>();    // Obtiene el componente GuardianScript del objeto de juego.
        audioSource.clip = backgroundMusic;    // Asigna la m�sica de fondo al AudioSource.
        audioSource.Play();    // Comienza a reproducir la m�sica de fondo.
        StartCoroutine(CheckPlayerDistance());    // Inicia una coroutina para comprobar la distancia al jugador.
        availableGuardians = GameObject.Find("GuardianBox");    // Busca el objeto de juego con el nombre "GuardianBox".

        cameraFx = GetComponent<CameraChange>();    // Obtiene el componente CameraChange del objeto de juego.

        detected = false;    // Inicializa detected a false.

        cameraFx.deactivateEffect();    // Desactiva los efectos de c�mara.

    }

    IEnumerator CheckPlayerDistance()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);    // Calcula la distancia al jugador.
            if (distanceToPlayer < 12f && distanceToPlayer > 1f && !persecucion.following)    // Si el jugador est� a una distancia entre 1 y 12 unidades y el monstruo no est� persiguiendo al jugador.
            {
                ChangeMusic(approachMusic);    // Cambia la m�sica a la m�sica de aproximaci�n.
            }
            else if (distanceToPlayer >= 12f)    // Si el jugador est� a una distancia mayor o igual a 12 unidades.
            {
                ChangeMusic(backgroundMusic);    // Cambia la m�sica a la m�sica de fondo.
            }
            else if (persecucion.following)    // Si el monstruo est� siguiendo al jugador.
            {
                persecucion.following = false;
                ChangeMusic(chaseMusic);    // Cambia la m�sica a la m�sica de persecuci�n.
            }
            yield return new WaitForSeconds(1f); // Comprueba la distancia cada segundo 
        }
    }

    void ChangeMusic(AudioClip newClip)    // M�todo para cambiar la m�sica.
    {
        if (audioSource.clip != newClip)    // Si la m�sica actual es diferente de la nueva m�sica.
        {
            audioSource.Stop();    // Detiene la m�sica actual.
            audioSource.clip = newClip;    // Asigna la nueva m�sica al AudioSource.
            audioSource.Play();    // Comienza a reproducir la nueva m�sica.
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 12f && Vector3.Distance(transform.position, player.position) > 1f)    // Si el jugador est� a una distancia entre 1 y 12 unidades.
        {
            detected = true; // Marca que el jugador ha sido detectado.
            print("Efecto activado"); // Imprime un mensaje en la consola.
            cameraFx.activateEffect(); // Activa los efectos de c�mara.
        }
        else if (detected)    // Si el jugador ha sido detectado.
        {
            print("Efecto desactivado"); // Imprime un mensaje en la consola.
            detected = false; // Marca que el jugador ya no est� detectado.
            cameraFx.deactivateEffect(); // Desactiva los efectos de c�mara.
        }
    }

    private void OnDestroy()    // M�todo que se llama cuando el objeto de juego es destruido.
    {
        if (cameraFx != null)    // Si hay un componente CameraChange.
        {
            cameraFx.deactivateEffect();    // Desactiva los efectos de c�mara.
        }
    }

}