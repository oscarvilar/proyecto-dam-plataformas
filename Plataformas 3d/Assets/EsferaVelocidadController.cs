using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsferaVelocidadController : MonoBehaviour {
    GameObject player;
    PlayerController playerController;
    public float boost = 0.0f;
    bool timer_activado = false;
    public Text tiempoText;
    float tiempo = 5f;
    //public GameObject esfera_velocidad;



    // Use this for initialization
    void Start () {
        tiempoText.enabled = true;
        player = GameObject.Find("Player");//buscamos el objeto con el nombre Player
        playerController = player.GetComponent<PlayerController>();//accede al script PlayerController

    }
	
	// Update is called once per frame
	void Update () {
        iniciar_cuenta_atras();
    }

    void boost_velocidad()
    {
        playerController.runSpeed = playerController.runSpeed * boost;
        //Destroy(esfera_velocidad);
    }

    void iniciar_cuenta_atras()
    {
        if (timer_activado)
        {
            tiempoText.enabled = true;
            tiempo -= Time.deltaTime;
            tiempoText.text = "" + tiempo.ToString("f0");

            if(tiempo <= 0)
            {
                tiempo = 0;
                tiempoText.enabled = false;
                playerController.runSpeed = 6;

            }
        }
        else
        {
            tiempoText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            timer_activado = true;
            tiempo = 5f;
            boost_velocidad();
        }
    }
}
