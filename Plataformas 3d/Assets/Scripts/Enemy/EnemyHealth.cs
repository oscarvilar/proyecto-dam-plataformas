using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;            
    public int currentHealth;
    public GameObject enemy;
    Animator anim;                                                                
    //CapsuleCollider capsuleCollider;            
    bool isDead;                               
    EnemyController enemyController;
    


    void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
        //capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
            Debug.Log("Enemigo muerto");
        }
    }


    void Death()
    {
        isDead = true;

       // capsuleCollider.isTrigger = true;
        anim.SetTrigger("Dead");
        enemyController.enabled=false;
 
    }

    public void DestroyEnemy()
    {
        Destroy(enemy);
    }

}
