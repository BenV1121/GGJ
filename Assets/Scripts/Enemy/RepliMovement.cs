﻿using UnityEngine;
using System.Collections;

public class RepliMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    int instanceID;


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.speed = 10;
        nav.angularSpeed = 300;
        instanceID = GetInstanceID();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.lives > 0)
        {
            transform.Translate(0, 0, -.5f * Time.deltaTime);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}