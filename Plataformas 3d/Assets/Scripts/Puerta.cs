using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta : MonoBehaviour {

    public GameObject puerta_derecha;
    public GameObject puerta_izquierda;
    public GameObject player;
    public Text texto_puerta;
    public GameObject moneda;
    bool puedo_abrir;
    bool puerta_abierta;
    // Use this for initialization
    void Start () {
        texto_puerta.enabled = false;
        puedo_abrir = false;
        puerta_abierta = false;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("B") || Input.GetKeyDown("b"))&& puerta_abierta == false)
        {
             abrir();
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            if (puerta_abierta == false)
            {
                texto_puerta.enabled = true;
                puedo_abrir = true;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == player)
        {
            texto_puerta.enabled = false;
            puedo_abrir = false;
        }
    }

    private void abrir()
    {
        //SI PULSO "B" Y TENGO SUFICIENTES MONEDAS
        if (puedo_abrir == true && moneda.GetComponent<ScoreController>().get_cantidad() >= 5)
        {
            //ANIMATOR SET TRIGGER abrir
            puerta_derecha.GetComponent<Animator>().SetTrigger("abrir");
            puerta_izquierda.GetComponent<Animator>().SetTrigger("abrir");

            //restar monedas
            moneda.GetComponent<ScoreController>().pagar_monedas(5);
            puerta_abierta = true;
        }

    }
}
