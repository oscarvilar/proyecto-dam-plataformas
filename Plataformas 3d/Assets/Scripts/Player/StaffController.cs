using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour {

    GameObject enemy;
    EnemyHealth enemyHealth;
    public int attackDamage;
    public bool inRange;
    GameObject player;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            anim.SetTrigger("MeleeAttack");
            if (enemyHealth.currentHealth > 0 && inRange == true)
            {
                enemyHealth.TakeDamage(attackDamage);
            }

        }

    }



     void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == enemy)
        {
            inRange = true;
            Debug.Log(inRange);
        }
    }


    public void OnTriggerExit(Collider other)
    {


        if (other.gameObject == enemy)
        {
            inRange = false;
            Debug.Log(inRange);
        }
                
        }

}
