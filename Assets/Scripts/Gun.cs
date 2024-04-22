using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public int ammo = 10;

    AudioManager audioManager;

    public TextMeshProUGUI bulletcount;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        bulletcount.text = "Bullets: " + ammo;
    }

    private void Update()
    {
        if (ammo <= 3 && ammo > 1)
        {
            bulletcount.color = Color.yellow;
        }

        if (ammo == 0)
        {
            bulletcount.color = Color.red;
        }


        if (Input.GetMouseButtonDown(0) && ammo == 0)
        {
            bulletcount.text = "Bullets: " + ammo;
            audioManager.playSFX(audioManager.gunnoammo);
            
        }

        if (Input.GetMouseButtonDown(0) && ammo >0)
        {
            ammo--;
            bulletcount.text = "Bullets: " + ammo;
            audioManager.playSFX(audioManager.gunshoot);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            
        }

        

    }
}
