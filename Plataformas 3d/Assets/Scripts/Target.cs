using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MarcarEnemigoCercano(0, 50);
	}
    // el metedo recibe la distancia minima y maxima para marcar a un enemigo
    public GameObject MarcarEnemigoCercano(float min, float max)
    {
        //Crear un array de game objects y guardar todos los objeros que tengan el tag enemy
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject mas_cercano = null;
        float distancia = Mathf.Infinity;
        //posicion del jugador
        Vector3 position = transform.position;

        //calcular distancia al cuadrado
        min = min * min;
        max = max * max;
        
        //por cada enemigo en el array...
        foreach (GameObject enemigo in enemigos)
        {
            //...calcular la distancia
            Vector3 diff = enemigo.transform.position - position;

            //cuDistancia  = diff al cuadrado
            float cuDistancia = diff.sqrMagnitude;


            if (cuDistancia < distancia && cuDistancia >= min && cuDistancia <= max)
            {
                mas_cercano = enemigo;
                distancia = cuDistancia;
                Debug.Log(mas_cercano);
            }
        }
        return mas_cercano;
        
    }
}
