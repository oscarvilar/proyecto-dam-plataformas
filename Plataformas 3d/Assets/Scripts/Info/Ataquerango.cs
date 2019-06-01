using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ataquerango : MonoBehaviour {

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
            info.text = "Las esferas rojas dan munición, pulsa CLICK IZQ/Y para atacar a distancia";
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
