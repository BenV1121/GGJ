﻿using UnityEngine;
using System.Collections;

public class RepliMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
    int instanceID;
    private float offset = 0;


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.speed = 0f;
        nav.angularSpeed = 0f;
        instanceID = GetInstanceID();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.lives > 0)
        {
            transform.Translate(0, 0, -1f * Time.deltaTime);
            
            /*
            Vector3 dest = player.position;
            dest.x += 4 * Mathf.Cos(2 * Time.time + instanceID);
            dest.z += 4 * Mathf.Cos(2 * Time.time + instanceID);
            GetComponent<Transform>().Rotate(dest);

    */
            if (GetComponent<Transform>().position.z < -30)
                Destroy(gameObject);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}