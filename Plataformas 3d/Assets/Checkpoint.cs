using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public GameObject player;
    public GameMaster gm;

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
            gm.ultimo_checkpoint = transform.position;
            Debug.Log("ultimo checkpoint =" + gm.ultimo_checkpoint);
        }
    }

}
