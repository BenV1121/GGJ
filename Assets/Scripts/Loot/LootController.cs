using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{

    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;
    public int lootenum;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            Looted(playerHealth);
        }

    }

    public void Looted(PlayerHealth playerHealth)
    {
        playerHealth.LootPickup(lootenum);
        Destroy(gameObject);
    }

    public void SetLoot(int ltenum)
    {
        lootenum = ltenum;
    }
}
