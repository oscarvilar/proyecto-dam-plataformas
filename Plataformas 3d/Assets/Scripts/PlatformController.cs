using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject player;
    int current = 0;
    public float speed;
    float WPradius = 1;

    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
