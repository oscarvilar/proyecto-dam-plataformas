using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {

    public int playerAttackDamage;
    public GameObject player;
    Animator anim;
    bool hit;
    EnemyHealth enemyHealth;
    
    
    // Use this for initialization
    void Start () {
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("X") || Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("MeleeAttack");
            if (hit)
            {
                {
                    enemyHealth.TakeDamage(playerAttackDamage);
                }
            }
        }
    }


    private void OnTriggerStay(Collider weaponCollider)
    {
        if (weaponCollider.gameObject.tag == "HitBoxEnemy")
        {
           enemyHealth =  weaponCollider.gameObject.GetComponentInParent<EnemyHealth>();
           hit = true;
        }
    }

}
