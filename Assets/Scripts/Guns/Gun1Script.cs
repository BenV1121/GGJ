using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1Script : GunScript
{

    public int damagePerShot;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets;        // The time between each shot.
    public float range;                      // The distance the gun can fire.
    public float effectsDisplayTime;                // The proportion of the timeBetweenBullets that the effects will display for.
    public float startwidth;
    public float endwidth;
    public Light faceLight;                             // Duh
    public GameObject gunLine1Object;                           // Reference to the line renderer.
    private float effectTimer = 0f;

    private bool active = false;

    private LineRenderer gunLine1;
    Ray shootRay = new Ray();                       // A ray from the gun end forwards.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    ParticleSystem gunParticles;                    // Reference to the particle system.
    GameObject player;
    PlayerHealth playerHealth;
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.


    private void Awake()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");

        // Set up the references.
        gunParticles = GetComponent<ParticleSystem>();
        gunLine1 = gunLine1Object.GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();

        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        effectTimer += Time.deltaTime;
        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (effectTimer >= effectsDisplayTime && active)
        {
            // ... disable the effects.
            DisableEffects();
            effectTimer = 0f;
        }
    }

    public override void Shoot(float timer, PlayerShooting shootingControl)
    {

        if (timer >= timeBetweenBullets && Time.timeScale != 0 && !playerHealth.dead && !playerHealth.end)
        {

            shootingControl.ResetTimer();
            effectTimer = 0f;
            // Play the gun shot audioclip.
            gunAudio.Play();

            // Enable the lights.
            gunLight.enabled = true;
            faceLight.enabled = true;

            // Stop the particles from playing if they were, then start the particles.
            gunParticles.Stop();
            gunParticles.Play();

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine1.enabled = true;
            gunLine1.SetPosition(0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            RaycastHit shootHit;

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                // Try and find an EnemyHealth script on the gameobject hit.
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                // If the EnemyHealth component exist...
                if (enemyHealth != null)
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine1.SetPosition(1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine1.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }

    }

    public override void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine1.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }

    public override void SwitchIn()
    {
        gunLine1.startWidth = startwidth;
        gunLine1.endWidth = endwidth;
        active = true;
        effectTimer = 0f;
    }

    public override void SwitchOut()
    {
        DisableEffects();
        active = false;
    }
}