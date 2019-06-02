using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Municion : MonoBehaviour
{
    public Text ui_municion;
    public static int cantidad = 0;
    public GameObject player;
    public GameObject moneda;
    Collider moneda_collider;
    MeshRenderer moneda_modelo;

    // Use this for initialization
    void Start()
    {
        ui_municion.enabled = true;
        moneda_collider = moneda.GetComponent<BoxCollider>();
        moneda_modelo = moneda.GetComponentInChildren<MeshRenderer>();
        moneda_collider.enabled = true;
        moneda_modelo.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        ui_municion.text = cantidad.ToString();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            cantidad+=10;
            moneda_collider.enabled = false;
            moneda_modelo.enabled = false;
        }
    }

    public int getCantidadMunicion()
    {
        int cantidad_municion = cantidad;
        return cantidad_municion;
    }

    public void bajarMunicion()
    {
        cantidad--;
    }

}
