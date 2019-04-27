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
    public GameObject esfera_velocidad;
    SphereCollider esfera_velocidad_collider;
    MeshRenderer esfera_velocidad_modelo;


    // Use this for initialization
    void Start () {
        tiempoText.enabled = true;
        player = GameObject.Find("Player");//buscamos el objeto con el nombre Player
        playerController = player.GetComponent<PlayerController>();//accede al script PlayerController
        esfera_velocidad_collider = esfera_velocidad.GetComponent<SphereCollider>();
        esfera_velocidad_modelo = esfera_velocidad.GetComponentInChildren<MeshRenderer>();
        esfera_velocidad_collider.enabled = true;
        esfera_velocidad_modelo.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        iniciar_cuenta_atras();
    }

    void boost_velocidad()
    {
        playerController.runSpeed = playerController.runSpeed * boost;
        
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
                Destroy(esfera_velocidad);

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
            esfera_velocidad_collider.enabled = false;
            esfera_velocidad_modelo.enabled = false;
            timer_activado = true;
            tiempo = 5f;
            boost_velocidad();
        }
    }
}
