using UnityEngine;


public class ColisionesBoss : MonoBehaviour
{
    HealthBar healthBar;

    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>(); // Encuentra el objeto con el script HealthBar y lo asigna a la variable healthBar.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "qu") //Si el otro gameobject con el que colisiona es el Xenomorph...
        {
            healthBar.currentHealth -= 20;
            Score.contador -= 50;
        }
    }
}