using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class Gun3Script : GunScript
    {

        public int damagePerShot;                  // The damage inflicted by each bullet.
        public float timeBetweenBullets;        // The time between each shot.
        public float range;                      // The distance the gun can fire.
        public float effectsDisplayTime;                // The proportion of the timeBetweenBullets that the effects will display for.
        public float startwidth;
        public float endwidth;
        public Light faceLight;                             // Duh
        public GameObject gunLine1Object;                           // Reference to the line renderer.
        public GameObject gunLine2Object;                           // Reference to the line renderer.
        public GameObject gunLine3Object;                           // Reference to the line renderer.
        private float effectTimer = 0f;

        private bool active = false;
        private LineRenderer gunLine1;
        private LineRenderer gunLine2;
        private LineRenderer gunLine3;


        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
        ParticleSystem gunParticles;                    // Reference to the particle system.

        AudioSource gunAudio;                           // Reference to the audio source.
        Light gunLight;                                 // Reference to the light component.


        private void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable");

            // Set up the references.
            gunParticles = GetComponent<ParticleSystem>();
            gunLine1 = gunLine1Object.GetComponent<LineRenderer>();
            gunLine2 = gunLine2Object.GetComponent<LineRenderer>();
            gunLine3 = gunLine3Object.GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
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

            if (timer >= timeBetweenBullets && Time.timeScale != 0)
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

                // Enable the line renderer and set it's first position to be the end of the gun.
                gunLine2.enabled = true;
                gunLine2.SetPosition(0, transform.position);

                // Enable the line renderer and set it's first position to be the end of the gun.
                gunLine3.enabled = true;
                gunLine3.SetPosition(0, transform.position);

                Ray shootRay1 = new Ray();                       // A ray from the gun end forwards.
                Ray shootRay2 = new Ray();                       // A ray from the gun end forwards.
                Ray shootRay3 = new Ray();                       // A ray from the gun end forwards.
                RaycastHit shootHit1;                            // A raycast hit to get information about what was hit.
                RaycastHit shootHit2;                            // A raycast hit to get information about what was hit.
                RaycastHit shootHit3;                            // A raycast hit to get information about what was hit.

                // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
                shootRay1.origin = transform.position;
                shootRay1.direction = transform.forward;
                

                // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
                shootRay2.origin = transform.position;
                shootRay2.direction = Quaternion.Euler(0, -15, 0) * transform.forward;
                

                // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
                shootRay3.origin = transform.position;
                shootRay3.direction = Quaternion.Euler(0, 15, 0) * transform.forward;

                // Perform the raycast against gameobjects on the shootable layer and if it hits something...
                if (Physics.Raycast(shootRay1, out shootHit1, range, shootableMask))
                {
                    // Try and find an EnemyHealth script on the gameobject hit.
                    EnemyHealth enemyHealth = shootHit1.collider.GetComponent<EnemyHealth>();

                    // If the EnemyHealth component exist...
                    if (enemyHealth != null)
                    {
                        // ... the enemy should take damage.
                        enemyHealth.TakeDamage(damagePerShot, shootHit1.point);
                    }

                    // Set the second position of the line renderer to the point the raycast hit.
                    gunLine1.SetPosition(1, shootHit1.point);
                }
                // If the raycast didn't hit anything on the shootable layer...
                else
                {
                    // ... set the second position of the line renderer to the fullest extent of the gun's range.
                    gunLine1.SetPosition(1, shootRay1.origin + shootRay1.direction * range);
                }


                // Perform the raycast against gameobjects on the shootable layer and if it hits something...
                if (Physics.Raycast(shootRay2, out shootHit2, range, shootableMask))
                {
                    // Try and find an EnemyHealth script on the gameobject hit.
                    EnemyHealth enemyHealth = shootHit2.collider.GetComponent<EnemyHealth>();

                    // If the EnemyHealth component exist...
                    if (enemyHealth != null)
                    {
                        // ... the enemy should take damage.
                        enemyHealth.TakeDamage(damagePerShot, shootHit2.point);
                    }

                    // Set the second position of the line renderer to the point the raycast hit.
                    gunLine2.SetPosition(1, shootHit2.point);
                }
                // If the raycast didn't hit anything on the shootable layer...
                else
                {
                    // ... set the second position of the line renderer to the fullest extent of the gun's range.
                    gunLine2.SetPosition(1, shootRay2.origin + shootRay2.direction * range);
                }

                // Perform the raycast against gameobjects on the shootable layer and if it hits something...
                if (Physics.Raycast(shootRay3, out shootHit3, range, shootableMask))
                {
                    // Try and find an EnemyHealth script on the gameobject hit.
                    EnemyHealth enemyHealth = shootHit3.collider.GetComponent<EnemyHealth>();

                    // If the EnemyHealth component exist...
                    if (enemyHealth != null)
                    {
                        // ... the enemy should take damage.
                        enemyHealth.TakeDamage(damagePerShot, shootHit3.point);
                    }

                    // Set the second position of the line renderer to the point the raycast hit.
                    gunLine3.SetPosition(1, shootHit3.point);
                }
                // If the raycast didn't hit anything on the shootable layer...
                else
                {
                    // ... set the second position of the line renderer to the fullest extent of the gun's range.
                    gunLine3.SetPosition(1, shootRay3.origin + shootRay3.direction * range);
                }
            }

        }

        public override void DisableEffects()
        {
            // Disable the line renderer and the light.
            gunLine1.enabled = false;
            gunLine2.enabled = false;
            gunLine3.enabled = false;
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
}