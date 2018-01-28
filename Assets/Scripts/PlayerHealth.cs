using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxLives = 5;
        public int lives = 5;
        public Text livesCount;
        private bool invincible = false;
        Renderer render;
        public GameObject shield;
        ShieldController shieldController;

    bool dead;
        public float respawnTimer = 2;

        void Start()
        {
            livesCount.text = "Lives: " + lives.ToString();
            dead = false;
            render = GetComponent<Renderer>();
            shieldController = shield.GetComponent<ShieldController>();
            invincible = false;
        }

        void Update()
        {
            if (Input.GetKeyDown("p"))
            {
                lives -= 1;
                render.enabled = false;
                dead = true;
                SetCountText();
            }

            if (Input.GetKeyDown("="))
            {
                Shield();
            }

            if (Input.GetKeyDown("-"))
            {
                HealthRegen();
            }


            if (dead)
            {
                respawnTimer -= 1 * Time.deltaTime;
            }
            else if (!dead)
            {
                respawnTimer = 7;
            }

            if (respawnTimer <= 0)
            {
                dead = false;
                render.enabled = true;
                transform.position = new Vector3(0, -4, 0);
            }

            if (lives <= 0)
            {
                // Gameover
            }
        }

        void OnTriggerEnter()
        {

        }

        void SetCountText()
        {
            livesCount.text = "Lives: " + lives.ToString();
        }



        public void LootPickup(int lootenum)
        {
            //TODO
        }

        public void HealthRegen()
        {
            lives = lives + 1;
            if (lives > maxLives)
            {
                lives = maxLives;
            }
            //TODO
            //damageImage.color = regenColor;
            //healthSlider.value = currentHealth;
        }

        public void Shield()
        {
            shieldController.ShieldEnable(this);
        }

        public void ShieldOn()
        {
            invincible = true;
        }

        public void ShieldOff()
        {
            invincible = false;
        }
    }
}