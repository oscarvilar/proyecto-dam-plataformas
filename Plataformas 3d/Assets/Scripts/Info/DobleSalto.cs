﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DobleSalto : MonoBehaviour {

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
            info.text = "Puedes pulsar 2 veces ESPACIO/A para saltar 2 veces";
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
