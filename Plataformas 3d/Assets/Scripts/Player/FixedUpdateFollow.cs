using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateFollow : MonoBehaviour {

    public Transform toFollow;
	// Update is called once per frame
	private void FixedUpdate () {
        transform.position = toFollow.position;
        transform.rotation = toFollow.rotation;
    }
}
