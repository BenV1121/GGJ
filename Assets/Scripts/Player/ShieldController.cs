using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour
{

    public bool shieldOn = false;
    public int shieldMaxBlock;
    public int shieldHealth;
    private PlayerHealth player;
    private bool damaged;
    public Image damageImage;
    public Color shieldColor;
    public float flashSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = shieldColor;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Health" + shieldHealth);
        shieldHealth = shieldHealth - amount;
        damaged = true;
        if (shieldHealth <= 0)
        {
            ShieldDisable();
        }

    }

    public void ShieldEnable(PlayerHealth playerHealth)
    {
        player = playerHealth;
        player.ShieldOn();
        shieldOn = true;
        shieldHealth = shieldMaxBlock;
        SphereCollider collider = GetComponent<SphereCollider>();
        collider.enabled = true;
        SkinnedMeshRenderer skin = GetComponent<SkinnedMeshRenderer>();
        skin.enabled = true;
        damageImage.color = shieldColor;
    }

    public void ShieldDisable()
    {
        shieldOn = false;
        player.ShieldOff();
        SkinnedMeshRenderer skin = GetComponent<SkinnedMeshRenderer>();
        skin.enabled = false;
        SphereCollider collider = GetComponent<SphereCollider>();
        collider.enabled = false;
    }

}