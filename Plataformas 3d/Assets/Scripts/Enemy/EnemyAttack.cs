using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 3f;


    public GameObject enemy;
    Animator anim;   
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;        
    EnemyController enemyController;

    void Start()
    {
        anim = enemy.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyController = enemy.GetComponent<EnemyController>();
    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject == player)
        {
            playerInRange = true;
            Debug.Log("playerInRange" + playerInRange);
        }
    }


    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {
            playerInRange = false;
            Debug.Log("playerInRange"+playerInRange);
        }
    }


    void Update()
    {

        if (playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
    }
    

    void Attack()
    {
        anim.SetTrigger("Attack");
        //WeaponController Script en el arma del enemigo
    }
}