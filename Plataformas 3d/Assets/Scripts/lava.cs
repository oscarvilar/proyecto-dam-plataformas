using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {
   public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().Death();
        }
    }
}
