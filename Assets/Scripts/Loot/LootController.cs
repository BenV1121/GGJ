using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{

    GameObject player;                          // Reference to the player GameObject.
    PlayerHealth playerHealth;
    public int lootenum;
    public float scrollingSpeed;
    //0 live, 1 shield, 2-8 guns
    public Material m0;
    public Material m1;
    public Material m2;
    public Material m3;
    public Material m4;
    public GameObject lootModel;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, scrollingSpeed * Time.deltaTime);
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
        MeshRenderer skin = lootModel.GetComponent<MeshRenderer>();
        //0 live, 1 shield, 2-8 guns
        if (lootenum == 0)
        {
            skin.material = m0;
        }
        //0 live, 1 shield, 2-8 guns
        if (lootenum == 1)
        {
            skin.material = m1;
        }
        if (lootenum == 2)
        {
            skin.material = m2;
        }
        if (lootenum == 3)
        {
            skin.material = m3;
        }
        if (lootenum == 4)
        {
            skin.material = m4;
        }
    }
}
