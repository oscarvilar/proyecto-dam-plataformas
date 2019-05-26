using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    Vector3 direction;
    GameObject mas_cercano = null;
    EnemyHealth enemyHealth;
    public int rangeDamage;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (MarcarEnemigoCercano(0, 25) != null)
        {
           
            Vector3 direction = (MarcarEnemigoCercano(0, 25).transform.position - transform.position).normalized;
            Vector3 deltaPosition = speed * direction * Time.deltaTime;
            rb.MovePosition(transform.position + deltaPosition);
        }

        if (MarcarEnemigoCercano(0, 25) == null)
        {
            Destroy(this.gameObject);
        }

    }

    // el metedo recibe la distancia minima y maxima para marcar a un enemigo
    public GameObject MarcarEnemigoCercano(float min, float max)
    {
        //Crear un array de game objects y guardar todos los objeros que tengan el tag enemy
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("target");
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
                Debug.Log("Enemigo mas cercano= " + mas_cercano);
            }
        }
        return mas_cercano;

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "HitBoxEnemy")
        {
            enemyHealth = col.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(rangeDamage);
            Destroy(this.gameObject);

        }
    }
}

