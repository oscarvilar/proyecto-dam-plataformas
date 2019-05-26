using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour {

    public Rigidbody proyectile;
    public GameObject municion;
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("Y") || Input.GetMouseButtonDown(1)) && municion.GetComponent<Municion>().getCantidadMunicion()>=1)
        {
            shoot();
            municion.GetComponent<Municion>().bajarMunicion();
        }
	}

    void shoot()
    {
         Rigidbody proyectileclone = (Rigidbody)Instantiate(proyectile, transform.position, transform.rotation);
    }
}
