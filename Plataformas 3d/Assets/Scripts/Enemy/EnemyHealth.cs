using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;            
    public int currentHealth;
    public GameObject enemy;
    MeleeController meleController;
    Animator anim;                                                                                                           
    EnemyController enemyController;
    


    void Awake()
    {
        meleController = GetComponent<MeleeController>();
        enemyController = GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }


    public void TakeDamage(int amount)
    {
        if(amount > currentHealth)
        {
            Death();
        }
        else
        {
            currentHealth -= amount;
        }
        

        if (currentHealth == 0)
        {
            
            Death();
            Debug.Log("Enemigo muerto");
        }
    }


    void Death()
    {
        
        anim.SetTrigger("Dead");
        //animation event al final de la animacion que ejecuta DestroyEnemy()

        //enemy.GetComponent<EnemyController>().enabled = false;
        //enemy.GetComponent<NavMeshAgent>().enabled = false;
    }

    public void DestroyEnemy()
    {
        Destroy(enemy);
    }

}
