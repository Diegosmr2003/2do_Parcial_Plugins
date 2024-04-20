using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float ammo = 10;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo == 0)
        {
            audioManager.playSFX(audioManager.gunnoammo);
        }

        if (Input.GetMouseButtonDown(0) && ammo >0)
        {
            audioManager.playSFX(audioManager.gunshoot);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            ammo--;
        }
        
    }
}
