using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour {
    public GameObject player;
    private GameMaster gm;

    

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();
        
    }
	

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            gm.ultimo_checkpoint = transform.position;
            Debug.Log("ultimo checkpoint =" + gm.ultimo_checkpoint);
            SistemaGuardado.guardar(gm);
            
        }
    }

}
