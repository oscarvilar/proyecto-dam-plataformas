using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public GameObject pos_inicial;
    public GameObject platform;


	// Use this for initialization
	void Start () {
      
        platform.transform.position = pos_inicial.transform.position;
 
	}
	
	// Update is called once per frame
	void Update () {
        move();
    }

    void move()
    {
     transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
    }
}
