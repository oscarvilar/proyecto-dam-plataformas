using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;            
    public int currentHealth;
    public GameObject enemy;
    Animator anim;                                                                            
    bool isDead;                               
    EnemyController enemyController;
    public GameObject objeto;
    


    void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();

        }
    }


    void Death()
    {
        enemy.GetComponent<EnemyController>().enabled = false;
        enemy.GetComponent<NavMeshAgent>().enabled = false;
        isDead = true;
        anim.SetTrigger("Dead");
        Instantiate(objeto, transform.position, transform.rotation);

    }

    public void DestroyEnemy()
    {
        Destroy(enemy);
    }

}
