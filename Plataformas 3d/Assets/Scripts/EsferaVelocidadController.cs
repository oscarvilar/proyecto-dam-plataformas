using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsferaVelocidadController : MonoBehaviour
{
    GameObject player;
    PlayerController playerController;
    float boost = 0;
    bool timer_activado = false;
    public Text tiempoText;
    float tiempo = 5f;
    public GameObject esfera_velocidad;
    SphereCollider esfera_velocidad_collider;
    MeshRenderer esfera_velocidad_modelo;


    // Use this for initialization
    void Start()
    {
        tiempoText.enabled = true;
        player = GameObject.Find("Player");//buscamos el objeto con el nombre Player
        playerController = player.GetComponent<PlayerController>();//accede al script PlayerController
        //referencias a el objeto esfera_velocidad
        esfera_velocidad_collider = esfera_velocidad.GetComponent<SphereCollider>();
        esfera_velocidad_modelo = esfera_velocidad.GetComponentInChildren<MeshRenderer>();

        //Desactivar el trigger y el modelo de las esfera y destruirla cuando el efecto haya terminado
        //si se destruye en el ontriggerenter se cancela
        esfera_velocidad_collider.enabled = true;
        esfera_velocidad_modelo.enabled = true;

        //ajustar cuanto es el boost de velocidad de las esferas
        boost = playerController.runSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        iniciar_cuenta_atras();
        //El tiempo debe estar en el update para que se actualize en la pantalla cada vez que baja un segundo
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            //Ocultar el modelo y desactivar el trigger del objeto para que se destruya cuando haya terminado el efecto
            esfera_velocidad_collider.enabled = false;
            esfera_velocidad_modelo.enabled = false;
            //bool timer_activado = true para que se active el metodo que tiene que estar en el update para que se actualiza el contador
            timer_activado = true;
            //duracion de la cuenta atras
            tiempo = 5f;
            //cambiar la velocidad del jugador boost = velocidad acutual * cantidad
            playerController.runSpeed = boost;
        }
    }

    void iniciar_cuenta_atras()
    {
        // si el bool timer activado es true
        if (timer_activado)
        {
            //activar el campo de texto de la ui 
            tiempoText.enabled = true;
            //cuenta atras
            tiempo -= Time.deltaTime;
            //tiempo que muestra en la ui
            tiempoText.text = "" + tiempo.ToString("f0");

            //cuandoe el tiempo llega a 0
            if (tiempo <= 0)
            {
                tiempo = 0;
                //ocultar el timer de la ui
                tiempoText.enabled = false;
                //volcer a la velociad normal
                playerController.runSpeed = 6;
                //destruier objeto
                Destroy(esfera_velocidad);

            }

        }

    }

}
