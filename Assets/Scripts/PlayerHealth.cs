using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float lives = 5;
    public Text livesCount;

    bool dead;
    public float respawnTimer = 7;

    void Start()
    {
        livesCount.text = "Lives: " + lives.ToString();
        dead = false;
    }

    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            lives -= 1;
            gameObject.SetActive(false);
            transform.position = new Vector3(0, 4, 0);
            dead = true;
            SetCountText();
        }

        if (dead)
        {
            respawnTimer -= 1 * Time.deltaTime;
        }
        else if (!dead)
        {

        }

        if(lives <= 0)
        {

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
