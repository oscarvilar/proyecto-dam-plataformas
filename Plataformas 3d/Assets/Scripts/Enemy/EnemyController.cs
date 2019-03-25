using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    Transform player;   
    Transform enemy;
                
    NavMeshAgent nav;              
    Animator anim;

   
    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        AggroDistance();


    }

    void AggroDistance()
    {
        double aggro = Vector3.Distance(player.transform.position, enemy.transform.position);
        //Debug.Log(aggro);

        if (aggro < 10)
        {
            nav.SetDestination(player.position);
            anim.SetBool("Aggro", true);
        }

        else
        {
            
            anim.SetBool("Aggro", false);
        }


    }


}
