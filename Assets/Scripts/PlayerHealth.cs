using System.Collections;
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
                    render.enabled = false;
                    blink = false;
                    blinkTimer = blinkInterval;

                }
                else if (blinkTimer <= 0)
                {
                    render.enabled = true;
                    blink = true;
                    blinkTimer = blinkInterval;
                }
            }
            else if (!dead)
            {
                respawnTimer = respawnTimerMax;
                render.enabled = true;
                blink = true;
            }

            if (respawnTimer <= 0)
            {
                dead = false;
                transform.position = new Vector3(0, 0.5f, 0);
                render.enabled = true;

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
        if (lootenum == 3)
        {
            shootingController.Switch(2);
        }
        if (lootenum == 4)
        {
            shootingController.Switch(3);
        }
        if (lootenum == 5)
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