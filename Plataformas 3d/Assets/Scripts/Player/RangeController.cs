using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour {

    public Rigidbody proyectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Y"))
        {
            shoot();
        }
	}

    void shoot()
    {
        Rigidbody proyectileclone = (Rigidbody)Instantiate(proyectile, transform.position, transform.rotation);
    }
}
