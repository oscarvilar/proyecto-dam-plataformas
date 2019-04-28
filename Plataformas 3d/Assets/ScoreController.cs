using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public Text ui_score;
    public static int cantidad = 0;
    public GameObject player;
    public GameObject moneda;
    SphereCollider moneda_collider;
    MeshRenderer moneda_modelo;

    // Use this for initialization
    void Start () {
        ui_score.enabled = true;
        moneda_collider = moneda.GetComponent<SphereCollider>();
        moneda_modelo = moneda.GetComponentInChildren<MeshRenderer>();
        moneda_collider.enabled = true;
        moneda_modelo.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        ui_score.text = cantidad.ToString();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            cantidad++;
            moneda_collider.enabled = false;
            moneda_modelo.enabled = false;
        }
    }

}
