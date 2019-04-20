﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Curacion : MonoBehaviour {


    public Slider healthSlider;
    public GameObject player;
    int currentHelath;
    public int cantidad_curada;
    PlayerHealth playerHealth;
    public GameObject esfera_curacion;


    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
           comprobar_curacion();
        }
    }

    void curar()
    {
        playerHealth.currentHealth += cantidad_curada;
        healthSlider.value = playerHealth.currentHealth;
        Destroy(esfera_curacion);
    }

    void comprobar_curacion()
    {
        if(cantidad_curada > (playerHealth.startingHealth - playerHealth.currentHealth))
        {
            playerHealth.currentHealth = 100;
            healthSlider.value = 100;
        }
        else
        {
            curar();
        }
    }

}
