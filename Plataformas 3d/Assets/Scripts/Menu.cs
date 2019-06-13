using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void continuar()
    {

        string nivel = SistemaGuardado.cargar().nivel;
        if (nivel != null)
        {
            SceneManager.LoadScene(nivel);
        }
        else
        {
            SceneManager.LoadScene("Nivel 1");
        }
    }

    public void menu_seleccion()
    {
        SceneManager.LoadScene("Menu_seleccion_nivel");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void volver_menu_principal() {

        SceneManager.LoadScene("Menu");
    }

    public void nivel_1()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void nivel_2()
    {
        SceneManager.LoadScene("Nivel 2");
    }
}

