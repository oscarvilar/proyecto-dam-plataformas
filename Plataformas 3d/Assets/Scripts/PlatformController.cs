using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float initial_pos;
    public float final_pos;
    Transform platform;

	// Use this for initialization
	void Start () {
        platform = GetComponent<Transform>();	
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move()
    {
        platform.Translate(new Vector3(0, 0, 1)*Time.deltaTime);
    }
}
