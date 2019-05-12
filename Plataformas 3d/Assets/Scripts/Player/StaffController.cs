using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour {

    //EnemyHealth enemyHealth;
    public int playerAttackDamage;
    GameObject player;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("X"))
        {
            anim.SetTrigger("MeleeAttack"); 
        }

    }



     void OnTriggerEnter(Collider weaponCollider)
    {
        if (weaponCollider.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            weaponCollider.gameObject.GetComponent<EnemyHealth>().TakeDamage(playerAttackDamage);
        }
    }

}
