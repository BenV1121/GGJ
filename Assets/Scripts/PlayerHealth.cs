using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float lives = 5;
    public Text livesCount;
    Renderer render;

    bool dead;
    public float respawnTimer = 2;

    void Start()
    {
        livesCount.text = "Lives: " + lives.ToString();
        dead = false;
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            lives -= 1;
            render.enabled = false;
            dead = true;
            SetCountText();
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

        if(lives <= 0)
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
}
