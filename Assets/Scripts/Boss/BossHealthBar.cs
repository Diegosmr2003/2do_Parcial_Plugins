using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public Slider healthBarSlider; // Referencia al componente Slider de la barra de vida en el UI.
    public TextMeshProUGUI healthValueText; // Referencia al componente TextMeshProUGUI para mostrar la vida como un número.

    public int maxBossHealth;
    public int currentBossHealth;
    private int minBossHealth = 0;

    public XenomorphController xenomorphController; // Referencia al script del enemigo.
    public AudioClip deathSound; // El clip de audio para el sonido de muerte.
    private AudioSource audioSource; // El AudioSource para reproducir el sonido.

    // Start is called before the first frame update
    void Start()
    {
        currentBossHealth = maxBossHealth;
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource del enemigo.
    }

    // Update is called once per frame
    void Update()
    {
        healthValueText.text = currentBossHealth.ToString() + "/ " + maxBossHealth.ToString();
        healthBarSlider.value = currentBossHealth;
        healthBarSlider.maxValue = maxBossHealth;

        if (currentBossHealth <= minBossHealth)
        {
            xenomorphController.enabled = false; // Desactiva el script del enemigo.
            xenomorphController.animator.SetBool("Death", true); // Activa la animación de muerte.
            audioSource.PlayOneShot(deathSound); // Reproduce el sonido de muerte.
            Invoke("ChangeScene", 5f); // Cambia de escena después de 5 segundos.
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(6);
        Cursor.lockState = CursorLockMode.None; //Desactiva la función que hace que el cursor se quede centrado en la pantalla
        Cursor.visible = true; //Hace al cursor visible
    }
}