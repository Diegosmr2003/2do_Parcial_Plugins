using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Material glowMaterial;
    public float glowIntensity = 5f;
    public Color defaultEmissionColor;
    public Color interactedEmissionColor;
    public Animator animator;
    public KeyCode interactionKey;
    public Gun gun;

    [Header("----------Audio Source-----------")]
    [SerializeField]
    AudioSource effectSource;

    [Header("----------Audio Clip-----------")]
    public AudioClip openCrate;

    private bool hasBeenOpened = false; // Variable para rastrear si la caja ya ha sido abierta
    private bool isPlayerInside = false; // Variable para rastrear si el jugador está dentro de la caja

    private void Start()
    {
        glowMaterial.SetColor("_EmissionColor", defaultEmissionColor * glowIntensity);
        effectSource = GetComponent<AudioSource>();
        effectSource.clip = openCrate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && !hasBeenOpened && isPlayerInside)
        {
            glowMaterial.SetColor("_EmissionColor", interactedEmissionColor * glowIntensity);
            animator.SetTrigger("Open");
            effectSource.Play();

            gun.AddAmmo(3);

            hasBeenOpened = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JUGADOR"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JUGADOR"))
        {
            isPlayerInside = false;
        }
    }
}