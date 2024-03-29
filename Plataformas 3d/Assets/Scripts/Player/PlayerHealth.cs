﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int startingHealth = 100;                                //vida inicial
    public int currentHealth;                                       //Vida actual
    Slider healthSlider;                                     //Ref al slider (barra de vida)
    public Image damageImage;                                       //Ref imagen que aparece al perder vida
    public float flashSpeed = 5f;                                   //duracion imagen
    public Color flashColour = new Color(1f, 0f, 0f,0.1f);          //color rojo
    Animator animator;                                              //Ref al animator del player     
    PlayerController playerController;                              //Ref al script player controller
    bool isDead;
    bool damaged;
    public GameMaster gm;

    // Use this for initialization
    void Awake () {
        healthSlider = GameObject.FindGameObjectWithTag("HealthUi").GetComponent<Slider>();
        animator = GetComponent<Animator>();                        //GET COMPONENTES
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;                             //inicializar vida
    }


    // Update is called once per frame
    void Update () {

        //si el jugador recibe daño
        if (damaged)
        {
            //cambia color de damageImage a flashColour
            damageImage.color = flashColour;
        }
        //sino      
        else
        {
            //vuelve a transparente
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;

        if (isDead && (Input.GetKeyDown("space")|| Input.GetButtonDown("A")))
        {
            //revivir();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;


        if (currentHealth <= 0 && !isDead)
        {
            Death();
            
        }
    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Dead");
        playerController.enabled = false;

    }

//    private void revivir()
//    {
//        isDead = false;
//        playerController.enabled = true;
//        animator.SetTrigger("revive");
//        currentHealth = startingHealth;
//        transform.position = gm.ultimo_checkpoint;
//    }

}
