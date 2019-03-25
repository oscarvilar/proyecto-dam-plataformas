using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 3f;     // The time in seconds between each attack.
                                              // The amount of health taken away per attack.


    Animator animator;                              // Reference to the animator component.
    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;                  // Reference to the player's health.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.
    EnemyController enemyController;

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        animator.SetBool("InRange", false);
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            playerInRange = true;
            animator.SetBool("InRange", true);
        }
    }


    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {
            playerInRange = false;
            animator.SetBool("InRange", false);
            Debug.Log(playerInRange);
        }
    }


    void Update()
    {
        //por cada vez que se ejecuta el metodo update el timer aumenta (delta time para evitar problemas de desincronizacion de los fps)
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        // si el jugador muere
        if (playerHealth.currentHealth <= 0)
        {
            animator.SetTrigger("PlayerDead");
            enemyController.enabled = false;
        }
    }
    

    void Attack()
    {
        // Reset timer
        timer = 0f;
        animator.SetTrigger("Attack");


    }
}