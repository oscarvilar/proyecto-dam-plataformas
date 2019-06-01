using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar_nivel : MonoBehaviour {


    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Nivel 2");
    }
}
