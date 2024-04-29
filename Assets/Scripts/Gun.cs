using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint; //Le pasamos la posicion de donde spawneará la bala (que en este caso es el cañón de la pistola)
    public GameObject bulletPrefab; //El prefab de la bala
    public float bulletSpeed = 10; //Velocidad de la bala
    public int ammo = 10; //Municion

    AudioManager audioManager; //Le pasamos nuestro audiomanager con el compendio de sonidos

    public TextMeshProUGUI bulletcount; //Le pasamos el texto en pantalla que se encargará de contar las balas

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); //Obtenemos los audios de nuestro audioManager
        bulletcount.text = "Bullets: " + ammo; //Inicializamos el texto en pantalla con la cantidad inicial de balas
    }

    private void Update()
    {
        if (ammo <= 3 && ammo > 1) 
        {
            bulletcount.color = Color.yellow; //Cambia color de texto a amarillo
        }

        if (ammo == 0)
        {
            bulletcount.color = Color.red; //Cambia color de texto a rojo
        }


        if (Input.GetMouseButtonDown(0) && ammo == 0) //Si el jugador hace click izquierdo y no tiene balas disponibles
        {
            bulletcount.text = "Bullets: " + ammo; //Muestra el texto con 0 balas
            audioManager.playSFX(audioManager.gunnoammo); //Llamamos al audioManager con el sonido de sin balas
            
        }

        if (Input.GetMouseButtonDown(0) && ammo >0) //Si el jugador hace click izquierdo y si tiene balas disponibles
        {
            ammo--; //Le restamos 1 valor a nuestra variable de balas
            bulletcount.text = "Bullets: " + ammo; //Se actualiza el texto
            audioManager.playSFX(audioManager.gunshoot); //Llamamos al audioManager con el sonido de disparo
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); //Instanciamos un prefab de la bala con la posicion y rotacion del spawnPoint
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed; //Le damos la velocidad y direccion adecuada a la bala
            
        }

        

    }
}
