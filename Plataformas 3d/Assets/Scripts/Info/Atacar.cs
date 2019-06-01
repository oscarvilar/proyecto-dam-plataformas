using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atacar : MonoBehaviour {

    Text info;
    GameObject player;

    private void Start()
    {
        info = GameObject.FindGameObjectWithTag("info").GetComponent<Text>();
        info.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            Debug.Log("trigger texto");
            info.enabled = true;
            info.text = "Pulsa Click Izq/X para atacar";
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == player)
        {
            info.enabled = false;
            info.text = "";
        }
    }
}
