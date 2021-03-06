﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5;
    public int lives = 5;
    public Text livesCount;
    private bool invincible = false;
    public float respawnTimerMax;
    Renderer render;
    public GameObject shield;
    ShieldController shieldController;
    public GameObject gun;
    PlayerShooting shootingController;
    public bool dead;
    public float respawnTimer;
    public float blinkInterval ;
    public float blinkTimer;
    private bool blink;
    public bool win;
    public bool end;
    public Image damageImage;
    public GameObject shipModel;
    public Image[] lifeImages;



    void Start()
    {
        livesCount.text = "Lives: " + lives.ToString();
        dead = false;
        render = GetComponent<Renderer>();
        shieldController = shield.GetComponent<ShieldController>();
        shootingController = gun.GetComponent<PlayerShooting>();
        invincible = false;
        respawnTimer = respawnTimerMax;
        blink = true;
        blinkTimer = 0;
        win = false;
        end = false;

        CheckHealthAmount();
    }

    void CheckHealthAmount()
    {
        for (int i = 0; i < maxLives; i++)
        {
            if(lives <= i)
            {
                lifeImages[i].enabled = false;
            }
            else
            {
                lifeImages[i].enabled = true;
            }
        }
    }

    void Update()
    {


        if (end != true)
        {
            if (dead)
            {
                respawnTimer -= 1 * Time.deltaTime;
                blinkTimer -= Time.deltaTime;
                if (blink && blinkTimer <= 0)
                {
                    shipModel.SetActive(false);
                    blink = false;
                    blinkTimer = blinkInterval;

                }
                else if (blinkTimer <= 0)
                {
                    shipModel.SetActive(true);
                    blink = true;
                    blinkTimer = blinkInterval;
                }
            }
            else if (!dead)
            {
                respawnTimer = respawnTimerMax;
                shipModel.SetActive(true);
                blink = true;
            }

            if (respawnTimer <= 0)
            {
                dead = false;
                transform.position = new Vector3(0, 0.5f, 0);
                shipModel.SetActive(true);

                Shield();
                blink = true;
            }
        }

        if (lives <= 0)
        {
            end = true;
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
        //0 live, 1 shield, 2-8 guns
        if (lootenum==0)
        {
            HealthRegen();
        }
        //0 live, 1 shield, 2-8 guns
        if (lootenum == 1)
        {
            Shield();
        }
        if (lootenum == 2)
        {
            shootingController.Switch(2);
        }
        if (lootenum == 3)
        {
            shootingController.Switch(3);
        }
        if (lootenum == 4)
        {
            shootingController.Switch(4);
        }

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


    public void TakeDamage()
    {
        if (!invincible && !dead)
        {
            dead = true;
            lives = lives - 1;
            SetCountText();

            for (int i = 0; i < maxLives; i++)
            {
                if (lives <= i)
                {
                    lifeImages[i].enabled = false;
                }
                else
                {
                    lifeImages[i].enabled = true;
                }
            }
        }
        else if (invincible)
        {
            shieldController.TakeDamage(1);
        }


    }

    public void Win()
    {
        end = true;
        win = true;
    }
}