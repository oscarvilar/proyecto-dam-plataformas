using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public GameObject player;
    public Vector3 checkpoint_position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            checkpoint_position = player.transform.position;
            Debug.Log("checkpoint_position = " + checkpoint_position);
        }
    }

}
