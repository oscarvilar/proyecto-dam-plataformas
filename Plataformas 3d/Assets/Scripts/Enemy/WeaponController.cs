using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    GameObject player;
    PlayerHealth playerHealth;
    public int attackDamage;
    bool canHit;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerExit(Collider other)
    {
        //Si toco al jugador..
        if (other.gameObject == player)
        {
            //Y su vida es mayor a 0...
            if (playerHealth.currentHealth > 0)
            {
                //..El jugador recibe daño
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }

}
