using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public GameObject player;   
    public GameObject enemy;
                
    public NavMeshAgent nav;              
    Animator anim;
   
    void Awake()
    {
        // Set up the references.
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.enabled = false;
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject == player)
        {
            anim.SetBool("Aggro", true);
            nav.enabled = true;
            nav.SetDestination(player.transform.position);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Aggro", false);
        nav.enabled = false;


    }



}
