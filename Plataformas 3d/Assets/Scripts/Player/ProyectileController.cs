using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour {

    private GameObject target;
    private Rigidbody rb;
    public float speed;
    Vector3 direction;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("target");
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 direction = (target.transform.position - transform.position).normalized;

        Vector3 deltaPosition = speed * direction * Time.deltaTime;
        rb.MovePosition(transform.position + deltaPosition);

    }
}
