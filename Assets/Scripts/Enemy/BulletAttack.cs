﻿using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    public float timeBetweenGermBullets = 3f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    protected Animator anim;                              // Reference to the animator component.
    protected GameObject player;                          // Reference to the player GameObject.
    protected PlayerHealth playerHealth;                  // Reference to the player's health.
    protected EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    protected bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    public static float timer;                                // Timer for counting up to the next attack.

    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }


    void Update()
    {
        // Add the time since Update was last called to the timer.
        BulletAttack.timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (playerInRange)
        {
            // ... attack.
            Attack();
        }

        // If the player has zero or less health...
        //if(playerHealth.lives <= 0)
        //{
        //    // ... tell the animator the player is dead.
        //    anim.SetTrigger ("PlayerDead");
        //}
    }

    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        // Reset the timer.
        if (BulletAttack.timer > timeBetweenGermBullets)
        {
            BulletAttack.timer = 0f;

            // If the player has health to lose...
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            playerHealth.TakeDamage();
        }
    }
}